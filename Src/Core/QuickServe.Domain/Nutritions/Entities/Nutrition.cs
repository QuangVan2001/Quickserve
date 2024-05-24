using QuickServe.Domain.Common;
using QuickServe.Domain.Ingredients.Entities;

namespace QuickServe.Domain.Nutritions.Entities
{
    public class Nutrition : AuditableBaseEntity
    {
        public long? IngredientId { get; set; }
        public string? ImageUrl { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Vitamin { get; set; }
        public string? HealthValue { get; set; }
        public string? Nutrition1 { get; set; }


        public virtual Ingredient? Ingredient { get; set; }
    }
}