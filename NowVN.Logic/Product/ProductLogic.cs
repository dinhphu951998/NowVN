using Microsoft.EntityFrameworkCore;
using NowVN.Framework.Models;
using NowVN.Framework.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NowVN.Framework.ViewModels;

namespace NowVN.Framework.ProductLogic
{
    public interface IProductLogic : IBaseRepository<Product>
    {
        List<Product> GetProduct(BasePagination paging);


    }

    public class ProductLogic : BaseRepository<Product>, IProductLogic
    {
        public ProductLogic(NowVNSimulatorContext dbContext) : base(dbContext)
        {

        }

        public List<Product> GetProduct(BasePagination paging)
        {
            var products = _context.Product.Where(p => p.IsActive == true)
                                            .OrderBy(p => p.Id)
                                            .Skip((paging.Page - 1) * paging.Size)
                                            .Take(paging.Size);
            return products.ToList();
        }

        public override Product Find(int Id)
        {
            return _context.Find<Product>(Id);
        }

    }
}
