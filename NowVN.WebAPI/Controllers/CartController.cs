using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NowVN.Framework.Helpers;
using NowVN.Framework.Models;
using NowVN.Framework.ViewModels;
using NowVN.Logic.CartLogic;

namespace NowVN.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartController : NowVNController
    {
        private ICartLogic cartLogic;
        public CartController(ExtensionSettings extensionSettings, ICartLogic cartLogic) : base(extensionSettings)
        {
            this.cartLogic = cartLogic;
        }

        [HttpPost]
        public dynamic AddToCart(Cart cart)
        {
            return ExecuteInMonitoring(() =>
            {
                cart.UserId = this.CurrentUserId;
                return this.cartLogic.Add(cart);
            });
        }

        [HttpGet]
        public dynamic GetCart()
        {
            return ExecuteInMonitoring(() =>
            {
                return cartLogic.GetCartByUserId(this.CurrentUserId);
            });
        }


        [HttpDelete("{cartId}")]
        public dynamic DeleteCart(int cartId)
        {
            return ExecuteInMonitoring(() =>
            {
                this.cartLogic.DeleteCart(cartId);
                return null;
            });
        }


        [HttpPut("{cartId}")]
        public dynamic UpdateCart(int cartId, Cart cart)
        {
            return ExecuteInMonitoring(() =>
            {
                return this.cartLogic.UpdateCart(cartId, cart);
            });
        }


    }
}