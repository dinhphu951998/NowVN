using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NowVN.Framework;
using NowVN.Framework.Helpers;
using NowVN.Framework.Models;
using NowVN.Framework.ProductLogic;
using NowVN.Framework.ViewModels;
using NowVN.Framework.ViewModels.EntityViewModel;

namespace NowVN.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : NowVNController
    {
        private IProductLogic productLogic;

        public ProductsController(IProductLogic productLogic, ExtensionSettings extensionSettings) : base(extensionSettings)
        {
            this.productLogic = productLogic;
        }

        [HttpGet]
        [AllowAnonymous]
        public dynamic GetProduct(BasePagination paging)
        {
            return ExecuteInMonitoring(() =>
            {
                var products = this.productLogic.GetProduct(paging);
                return products.Select(p => p.ToViewModel<ProductViewModel>());
            });
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public dynamic GetProduct(int id)
        {
            return ExecuteInMonitoring(() =>
            {
                return productLogic.Find(id)?.ToViewModel<ProductViewModel>();
            });
        }

        [HttpPost]
        public dynamic AddNewProduct(Product product)
        {
            return ExecuteInMonitoring(() =>
            {
                return productLogic.Add(product)?.ToViewModel<ProductViewModel>();
            });
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public dynamic PutProduct(int id, Product updatedProduct)
        {
            return ExecuteInMonitoring(() =>
            {
                return productLogic.UpdateProduct(id, updatedProduct);
            });
        }


        [HttpDelete("{id}")]
        public dynamic DeleteProduct(int id)
        {
            return ExecuteInMonitoring(() =>
            {
                return productLogic.DeleteProduct(id);
            });
        }

    }
}
