using System;
using System.Collections.Generic;

namespace NowVN.Framework.Models
{
    public partial class Cart
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; }
    }
}
