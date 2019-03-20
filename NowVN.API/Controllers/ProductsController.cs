using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NowVN.Framework.Helpers;
using NowVN.Framework.Models;
using NowVN.Framework.ProductLogic;

namespace NowVN.API.Controllers
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
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            var products = this.productLogic.GetAll();
            return this.Ok(products);
        }

        //// GET: api/Products/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Product>> GetProduct(int id)
        //{
        //    var product = await _context.Product.FindAsync(id);

        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return product;
        //}

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

        //// POST: api/Products
        //[HttpPost]
        //public async Task<ActionResult<Product>> PostProduct(Product product)
        //{
        //    _context.Product.Add(product);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetProduct", new { id = product.Id }, product);
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
