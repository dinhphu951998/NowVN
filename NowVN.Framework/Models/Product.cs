using System;
using System.Collections.Generic;

namespace NowVN.Framework.Models
{
    public partial class Product
    {
        public Product()
        {
            Image = new HashSet<Image>();
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public bool? IsActive { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Image> Image { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
