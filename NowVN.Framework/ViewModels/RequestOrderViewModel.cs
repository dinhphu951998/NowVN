using NowVN.Framework.ViewModels.EntityViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NowVN.Framework.ViewModels
{
    public class RequestOrderViewModel
    {
        public string UserId { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Fullname { get; set; }

        public List<OrderDetailsViewModel> OrderDetails { get; set; }

    }
}
