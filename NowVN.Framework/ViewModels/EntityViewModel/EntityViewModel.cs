using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NowVN.Framework.ViewModels.EntityViewModel
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; }
    }

    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public  class CustomerViewModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public DateTime? Birthdate { get; set; }
        public DateTime? StartDate { get; set; }

    }

    public partial class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public bool? IsActive { get; set; }
    }

    public partial class OrderViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public double Total { get; set; }
        public bool? IsAvailable { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Fullname { get; set; }
        public string CustomerId { get; set; }
    }

    public partial class OrderDetailsViewModel
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }

    public partial class ImageViewModel
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int? ProductId { get; set; }
    }

}
