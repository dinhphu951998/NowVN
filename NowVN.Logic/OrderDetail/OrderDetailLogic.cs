using Microsoft.EntityFrameworkCore;
using NowVN.Framework.BaseRepository;
using NowVN.Framework.Models;
using NowVN.Framework.ProductLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NowVN.Logic.OrderDetailLogic
{
    public interface IOrderDetailLogic : IBaseRepository<OrderDetails>
    {
        List<OrderDetails> AddOrderDetail(List<OrderDetails> orderDetails);

    }

    public class OrderDetailLogic : BaseRepository<OrderDetails>, IOrderDetailLogic
    {
        private IProductLogic productLogic;
        public OrderDetailLogic(IProductLogic productLogic, NowVNSimulatorContext dbContext) : base(dbContext)
        {
            this.productLogic = productLogic;
        }

        public List<OrderDetails> AddOrderDetail(List<OrderDetails> orderDetails)
        {
            dbContext.AddRangeAsync(orderDetails);
            return orderDetails;
        }


    }
}
