using System;
using System.Collections.Generic;

namespace NowVN.Framework.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }

        public string Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public DateTime? Birthdate { get; set; }
        public DateTime? StartDate { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
