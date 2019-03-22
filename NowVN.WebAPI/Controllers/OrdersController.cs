using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NowVN.Framework.Helpers;
using NowVN.Framework.ViewModels;
using NowVN.Framework.ViewModels.EntityViewModel;
using NowVN.Logic.OrderLogic;

namespace NowVN.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : NowVNController
    {
        private IOrderLogic orderLogic;
        public OrdersController(IOrderLogic orderLogic, ExtensionSettings extensionSettings) : base(extensionSettings)
        {
            this.orderLogic = orderLogic;
        }

        [HttpGet]
        public dynamic GetOrder(BasePagination paging)
        {
            return ExecuteInMonitoring(() =>
            {
                return orderLogic.GetOrderPaging(paging);
            });
        }

        [HttpPost]
        public dynamic CreateOrder()
        {
            return ExecuteInMonitoring(() =>
            {
                return orderLogic.CreateOrder(this.CurrentUserId);
            });
        }


        [HttpDelete("{orderId}")]
        public dynamic DeleteOrder(int orderId)
        {
            return ExecuteInMonitoring(() =>
            {
                orderLogic.DeleteOrder(orderId);
                return null;
            });
        }



    }
}