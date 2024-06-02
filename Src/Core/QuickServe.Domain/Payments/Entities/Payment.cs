using QuickServe.Domain.Common;
using QuickServe.Domain.Orders.Entities;

namespace QuickServe.Domain.Payments.Entities
{
    public class Payment : AuditableBaseEntity
    {
        public Payment()
        {
            
        }

        public string Name { get; set; } = null!;
        public int PaymentType { get; set; }
        public long RefOrderId { get; set; }

        public virtual Order Order { get; set; } = null!;
    }
}