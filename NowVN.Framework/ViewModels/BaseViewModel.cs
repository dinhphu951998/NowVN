using AutoMapper;
using NowVN.Framework.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NowVN.Framework.ViewModels
{
    public partial class BaseViewModel
    {
        protected IMapper mapper {
            get {
                return AutoMapperConfiguration.GetInstance();
            }
        }

        public TDestination ToEntity<TDestination>()
        {
            return mapper.Map<TDestination>(this);
        }
    }
}
