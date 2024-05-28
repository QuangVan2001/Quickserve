using QuickServe.Domain.Common;
using QuickServe.Domain.IngredientNutritions.Entities;
using System.Collections.Generic;

namespace QuickServe.Domain.Nutritions.Entities
{
    public class Nutrition : AuditableBaseEntity
    {
        public string? ImageUrl { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Vitamin { get; set; }
        public string? HealthValue { get; set; }
        public int Status { get; set; }

        public virtual ICollection<IngredientNutrition>? IngredientNutritions { get; set; }
    }
}