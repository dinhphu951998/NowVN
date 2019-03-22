using Microsoft.EntityFrameworkCore;
using NowVN.Framework;
using NowVN.Framework.BaseRepository;
using NowVN.Framework.CustomerLogic;
using NowVN.Framework.Models;
using NowVN.Framework.ProductLogic;
using NowVN.Framework.ViewModels;
using NowVN.Framework.ViewModels.EntityViewModel;
using NowVN.Logic.CartLogic;
using NowVN.Logic.OrderDetailLogic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace NowVN.Logic.OrderLogic
{
    public interface IOrderLogic : IBaseRepository<Order>
    {
        List<OrderViewModel> GetOrderPaging(BasePagination paging);
        OrderViewModel CreateOrder(string userId);

        Task<int> DeleteOrder(int orderId);
    }

    public class OrderLogic : BaseRepository<Order>, IOrderLogic
    {
        private ICustomerLogic customerLogic;
        private ICartLogic cartLogic;
        private IProductLogic productLogic;
        private IOrderDetailLogic orderDetailLogic;

        public OrderLogic(NowVNSimulatorContext dbContext, ICartLogic cartLogic, 
                            ICustomerLogic customerLogic, IProductLogic productLogic, IOrderDetailLogic orderDetailLogic) 
            : base(dbContext)
        {
            this.customerLogic = customerLogic;
            this.cartLogic = cartLogic;
            this.productLogic = productLogic;
            this.orderDetailLogic = orderDetailLogic;
        }

        public List<OrderViewModel> GetOrderPaging(BasePagination paging)
        {
            var orders = dbContext.Order.Where(o => o.IsAvailable == true)
                                        .OrderBy(o => o.Id)
                                        .Skip((paging.Page - 1) * paging.Size)
                                        .Take(paging.Size);
            return orders.Select(o => o.ToViewModel<OrderViewModel>()).ToList();
        }

        public OrderViewModel CreateOrder(string userId)
        {
            Order order = null;

            Customer customer = dbContext.Customer.Where(c => c.Id.Equals(userId)).FirstOrDefault();
            var carts = this.cartLogic.GetCartByUserId(customer.Id);
            if(carts == null)
            {
                throw new NowVNException("Cart not found");
            }
            order = SaveOrder(customer.Id, customer.Address, customer.Phone, customer.Fullname, carts);
            this.cartLogic.DeleteByUserId(customer.Id);
            return order.ToViewModel<OrderViewModel>();
        }

        private Order SaveOrder(string customerId, string address, string phone, string fullname, List<Cart> carts)
        {
            Order order = null;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {

                var productIds = carts.Select(c => c.ProductId);
                var products = productLogic.GetProductByIds(productIds.ToArray());

                //firstly, prepare order detail 
                List<OrderDetails> orderDetails = carts.Select(c => new OrderDetails()
                {
                    Price = products.Where(p => p.Id == c.ProductId).First().Price,
                    ProductId = c.ProductId,
                    Quantity = c.Quantity
                }).ToList();

                //prepare order
                order = new Order()
                {
                    CustomerId = customerId,
                    Address = address,
                    Phone = phone,
                    Fullname = fullname,
                    Total = orderDetails.Sum(od => od.Quantity * od.Price),
                    OrderDetails = orderDetails
                };

                this.Add(order);

                scope.Complete();
            }
            return order;
        }

        public async Task<int> DeleteOrder(int orderId)
        {
            return await this.dbContext.Database.ExecuteSqlCommandAsync("delete from OrderDetails where orderId = @orderId;" +
                "delete from [Order] where Id = @orderId", new SqlParameter("@orderId", orderId));
        }
    }
}
