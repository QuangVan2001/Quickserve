using System.Collections.Generic;
using QuickServe.Domain.Common;
using QuickServe.Domain.Ingredients.Entities;
using QuickServe.Domain.IngredientTypeTemplateSteps.Entities;

namespace QuickServe.Domain.IngredientTypes.Entities
{
    public class IngredientType : AuditableBaseEntity
    {
        public IngredientType()
        {
            IngredientTypeTemplateSteps = new HashSet<IngredientTypeTemplateStep>();
            Ingredients = new HashSet<Ingredient>();
        }


        public string Name { get; set; } = null!;


        public virtual ICollection<IngredientTypeTemplateStep> IngredientTypeTemplateSteps { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}