using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NowVN.Framework.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static IMapper GetInstance()
        {
            return Mapper.Configuration.CreateMapper();
        }

    }
}
