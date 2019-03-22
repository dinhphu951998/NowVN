using Microsoft.EntityFrameworkCore;
using NowVN.Framework.Models;
using NowVN.Framework.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NowVN.Framework.ViewModels;
using NowVN.Framework.ViewModels.EntityViewModel;

namespace NowVN.Framework.ProductLogic
{
    public interface IProductLogic : IBaseRepository<Product>
    {
        List<Product> GetProduct(BasePagination paging);
        bool Any(int id);
        ProductViewModel UpdateProduct(int id, Product updatedProduct);

        ProductViewModel DeleteProduct(int id);

        List<Product> GetProductByIds(params int[] ids);
    }

    public class ProductLogic : BaseRepository<Product>, IProductLogic
    {
        public ProductLogic(NowVNSimulatorContext dbContext) : base(dbContext)
        {

        }

        public List<Product> GetProduct(BasePagination paging)
        {
            var products = dbContext.Product.Where(p => p.IsActive == true)
                                            .OrderBy(p => p.Id)
                                            .Skip((paging.Page - 1) * paging.Size)
                                            .Take(paging.Size);
            return products.ToList();
        }

        public override Product Find(int Id)
        {
            return dbContext.Find<Product>(Id);
        }

        public ProductViewModel UpdateProduct(int id, Product updatedProduct)
        {
            if (id == updatedProduct.Id)
            {
                var productEntity = this.Find(id);
                try
                {
                    this.Update(productEntity, updatedProduct);

                    return updatedProduct.ToViewModel<ProductViewModel>();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw new NowVNException("Entity not found");
                }

            }
            throw new NowVNException("Entity not found");
        }

        public bool Any(int id)
        {
            return dbContext.Product.Any(p => p.Id == id);
        }

        public ProductViewModel DeleteProduct(int id)
        {
            var productEntity = this.Find(id);
            if (productEntity != null)
            {
                this.Delete(productEntity);
            }
            return productEntity.ToViewModel<ProductViewModel>();
        }

        public List<Product> GetProductByIds(params int[] ids)
        {
            return dbContext.Product.Where(p => ids.Contains(p.Id)).ToList();
        }
    }
}
