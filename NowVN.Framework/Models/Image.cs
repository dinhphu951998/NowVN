using System;
using System.Collections.Generic;

namespace NowVN.Framework.Models
{
    public partial class Image
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int? ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
