using System;
using System.Collections.Generic;

namespace NowVN.Framework.Models
{
    public partial class Role
    {
        public Role()
        {
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
