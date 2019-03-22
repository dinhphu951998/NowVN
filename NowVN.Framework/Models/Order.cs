using System;
using System.Collections.Generic;

namespace NowVN.Framework.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
        public double Total { get; set; }
        public bool? IsAvailable { get; set; } = true;
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Fullname { get; set; }
        public string CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
