using AutoMapper;
using NowVN.Framework.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NowVN.Framework.Models
{
    public class BaseEntity
    {
        protected IMapper mapper {
            get {
                return AutoMapperConfiguration.GetInstance();
            }
        }

        public TDestination ToViewModel<TDestination>()
        {
            return mapper.Map<TDestination>(this);
        }
    }
}
