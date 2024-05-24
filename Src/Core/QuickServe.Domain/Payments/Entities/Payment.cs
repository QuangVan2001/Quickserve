using System.Collections.Generic;
using QuickServe.Domain.Common;
using QuickServe.Domain.Orders.Entities;

namespace QuickServe.Domain.Payments.Entities
{
    public class Payment : AuditableBaseEntity
    {
        public Payment()
        {
            Orders = new HashSet<Order>();
        }

        public string Name { get; set; } = null!;
        public PaymentMethod PaymentType ;
       
        public virtual ICollection<Order> Orders { get; set; }
    }
}