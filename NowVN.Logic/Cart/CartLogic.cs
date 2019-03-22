using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NowVN.Framework;
using NowVN.Framework.BaseRepository;
using NowVN.Framework.Helpers;
using NowVN.Framework.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NowVN.Logic.CartLogic
{
    public interface ICartLogic :IBaseRepository<Cart>
    {
        List<Cart> GetCartByUserId(string userId);
        void DeleteByUserId(string userId);
        void DeleteCart(int Id);

        Cart UpdateCart(int cartId, Cart cart);
    }

    public class CartLogic : BaseRepository<Cart>, ICartLogic
    {
        public CartLogic(NowVNSimulatorContext dbContext) : base(dbContext)
        {
        }

        public void DeleteByUserId(string userId)
        {
            this.dbContext.Database.ExecuteSqlCommandAsync("delete from Cart where userId = @userId", 
                                                                new SqlParameter("@userId", userId));
        }

        public List<Cart> GetCartByUserId(string userId)
        {
            return this.Get(c => c.UserId.Equals(userId)).ToList();
        }

        public override Cart Find(int Id)
        {
            return this.dbContext.Cart.Find(Id);
        }

        public void DeleteCart(int Id)
        {
            Cart cart = this.Find(Id);
            if(cart != null)
            {
                this.Delete(cart);
            }
        }

        public Cart UpdateCart(int cartId, Cart updatedCart)
        {
            var cartEntity = this.Find(cartId);
            if(cartEntity == null)
            {
                throw new NowVNException("Cart not found");
            }
            updatedCart.Id = cartId;
            updatedCart.UserId = cartEntity.UserId;
            this.Update(cartEntity, updatedCart);
            return updatedCart;

        }
    }
}
