using QuickServe.Domain.Common;
using QuickServe.Domain.Ingredients.Entities;
using QuickServe.Domain.Nutritions.Entities;

namespace QuickServe.Domain.IngredientNutritions.Entities
{
    public class IngredientNutrition : AuditableBaseEntity
    {
        public long IngredientId { get; set; }
        public long NutritionId { get; set; }

        public virtual Nutrition Nutrition { get; set; } = null!;
        public virtual Ingredient Ingredient { get; set; } = null!;
    }
}
