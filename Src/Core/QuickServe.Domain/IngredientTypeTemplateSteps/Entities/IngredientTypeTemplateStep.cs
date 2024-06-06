using System.Collections.Generic;
using QuickServe.Domain.Common;
using QuickServe.Domain.IngredientTypes.Entities;
using QuickServe.Domain.ProductTemplates.Entities;
using QuickServe.Domain.TemplateSteps.Entities;

namespace QuickServe.Domain.IngredientTypeTemplateSteps.Entities
{
    public class IngredientTypeTemplateStep : AuditableBaseEntity
    {
        public long IngredientTypeId { get; set; }
        public long TemplateStepId { get; set; }
        public int QuantityMin { get; set; }
        public int QuantityMax { get; set; }

        public virtual IngredientType IngredientType { get; set; } = null!;
        public virtual TemplateStep TemplateStep { get; set; } = null!;
    }
}