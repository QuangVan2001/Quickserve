using System;
using System.Collections.Generic;

using QuickServe.Domain.Common;

using QuickServe.Domain.OrderProducts.Entities;
using QuickServe.Domain.Payments.Entities;
using QuickServe.Domain.Stores.Entities;

namespace QuickServe.Domain.Orders.Entities
{
    public class Order : AuditableBaseEntity
    {
        public Order()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

    
        public long PaymentMethodId { get; set; }
        public Guid CustomerId { get; set; }
        public string Status { get; set; } = null!;
        public double TotalPrice { get; set; }
        public long StoreId { get; set; }

        
       
        public virtual Payment PaymentMethod { get; set; } = null!;
        public virtual Store Store { get; set; } = null!;
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }

   
}