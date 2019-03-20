using Microsoft.EntityFrameworkCore;
using NowVN.Framework.Models;
using NowVN.Framework.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NowVN.Framework.ProductLogic
{
    public interface IProductLogic : IBaseRepository<Product>
    {



    }

    public class ProductLogic : BaseRepository<Product>, IProductLogic
    {
        public ProductLogic(NowVNSimulatorContext dbContext) : base(dbContext)
        {

        }
    }
}
