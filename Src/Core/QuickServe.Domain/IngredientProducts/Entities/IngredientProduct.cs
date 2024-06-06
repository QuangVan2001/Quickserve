using QuickServe.Domain.Common;
using QuickServe.Domain.Ingredients.Entities;
using QuickServe.Domain.Products.Entities;

namespace QuickServe.Domain.IngredientProducts.Entities
{
    public class IngredientProduct  : AuditableBaseEntity
    {
        public long IngredientId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Ingredient Ingredient { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}