using System;
using System.Collections.Generic;
using QuickServe.Domain.Common;
using QuickServe.Domain.IngredientSessions.Entities;
using QuickServe.Domain.Orders.Entities;

namespace QuickServe.Domain.Sessions.Entities
{
    public class Session : AuditableBaseEntity
    {
        public Session()
        {
            IngredientSessions = new HashSet<IngredientSession>();
        }

     
        public string Name { get; set; } = null!;
        public long OrderId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int Status { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual ICollection<IngredientSession> IngredientSessions { get; set; }
    }
}