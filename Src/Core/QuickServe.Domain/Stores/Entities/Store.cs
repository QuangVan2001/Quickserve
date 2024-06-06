using System.Collections.Generic;
using QuickServe.Domain.Common;
using QuickServe.Domain.Orders.Entities;
using QuickServe.Domain.Staffs.Entities;

namespace QuickServe.Domain.Stores.Entities
{
    public class Store : AuditableBaseEntity
    {
        public Store()
        {
            Orders = new HashSet<Order>();
            Staffs = new HashSet<Staff>();
        }

        public Store(string name, string address)
        {
            Orders = new HashSet<Order>();
            Staffs = new HashSet<Staff>();
            Name = name;
            Address = address;
        }

        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;

        public void Update(string name, string address)
        {
            Name = name;
            Address = address;

        }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Staff> Staffs { get; set; }
    }
}