using System;
using System.Collections.Generic;
using QuickServe.Domain.Common;
using QuickServe.Domain.Ingredients.Entities;

namespace QuickServe.Domain.Sessions.Entities
{
    public class Session : AuditableBaseEntity
    {
        public Session()
        {
            Ingredients = new HashSet<Ingredient>();
        }

     
        public string Name { get; set; } = null!;
        public long IngredientId { get; set; }
        public long OrderId { get; set; }
        public long StoreId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }


        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}