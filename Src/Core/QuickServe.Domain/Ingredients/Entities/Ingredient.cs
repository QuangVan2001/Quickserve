using System.Collections.Generic;
using QuickServe.Domain.Common;
using QuickServe.Domain.IngredientProducts.Entities;
using QuickServe.Domain.IngredientTypes.Entities;
using QuickServe.Domain.Nutritions.Entities;
using QuickServe.Domain.Sessions.Entities;

namespace QuickServe.Domain.Ingredients.Entities
{
    public class Ingredient : AuditableBaseEntity
    {
        public Ingredient()
        {
            IngredientProducts = new HashSet<IngredientProduct>();
            Sessions = new HashSet<Session>();
        }

    
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int Calo { get; set; }
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public long IngredientTypeId { get; set; }


        public virtual IngredientType IngredientType { get; set; } = null!;
        public virtual Nutrition? Nutrition { get; set; }
        public virtual ICollection<IngredientProduct> IngredientProducts { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}