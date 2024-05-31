using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.DTOs.IngredientTypes.Request
{
    public class IngredientTypeTemplates
    {
        public int IngredientTypeId { get; set; }
        public int QuantityMin { get; set; }
        public int QuantityMax { get; set; }
    }
    public class IngredientTypeTemplateStepsValidator : AbstractValidator<IngredientTypeTemplates>
    {
        public IngredientTypeTemplateStepsValidator()
        {
            RuleFor(x => x.IngredientTypeId)
                .NotEmpty().WithMessage("IngredientTypeId is required.")
                .GreaterThan(0).WithMessage("IngredientTypeId must be greater than 0.");

            RuleFor(x => x.QuantityMin)
                .GreaterThanOrEqualTo(0).WithMessage("QuantityMin must be greater than or equal to 0.");

            RuleFor(x => x.QuantityMax)
                .GreaterThanOrEqualTo(x => x.QuantityMin).WithMessage("QuantityMax must be greater than or equal to QuantityMin.");
        }
    }
}
