using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NowVN.Framework.Helpers;
using NowVN.Framework.Models;
using NowVN.Framework.ProductLogic;
using NowVN.Framework.ViewModels;
using NowVN.Framework.ViewModels.EntityViewModel;

namespace NowVN.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : NowVNController
    {
        private IProductLogic productLogic;

        public ProductsController(IProductLogic productLogic, ExtensionSettings extensionSettings) : base(extensionSettings)
        {
            this.productLogic = productLogic;
        }

        [HttpGet]
        public async Task<dynamic> GetProduct(BasePagination paging)
        {
            return ExecuteInMonitoring(() =>
            {
                var products = this.productLogic.GetProduct(paging);
                return products.Select( p => p.ToViewModel<ProductViewModel>());
            });
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public dynamic GetProduct(int id)
        {
            return ExecuteInMonitoring(() =>
            {
                return productLogic.Find(id)?.ToViewModel<ProductViewModel>();
            });
        }

       [HttpPost]
       [Authorize]
        public dynamic AddNewProduct(Product product)
        {
            return ExecuteInMonitoring(() =>
            {
                product.CreatedTime = DateTime.UtcNow;
                product.IsActive = true;

                return productLogic.Add(product)?.ToViewModel<ProductViewModel>();
            });
        }

        //// PUT: api/Products/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutProduct(int id, Product product)
        //{
        //    if (id != product.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(product).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProductExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}



        //// DELETE: api/Products/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Product>> DeleteProduct(int id)
        //{
        //    var product = await _context.Product.FindAsync(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Product.Remove(product);
        //    await _context.SaveChangesAsync();

        //    return product;
        //}

        //private bool ProductExists(int id)
        //{
        //    return _context.Product.Any(e => e.Id == id);
        //}
    }
}
