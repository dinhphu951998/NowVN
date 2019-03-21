using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NowVN.Framework.ViewModels
{
    public class BaseRequest
    {

    }

    public class BasePagination
    {
        public int Total { get; set; } // total record
        public int Size { get; set; } //record per page
        public int Page { get; set; } // page number
    }
}
