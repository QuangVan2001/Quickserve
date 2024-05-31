using FluentValidation;
using QuickServe.Application.DTOs.IngredientTypes.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.DTOs.ProductTemplates.Request
{
    public class CreateTemplateRequest
    {
        public long TemplateStepId { get; set; }
        public List<IngredientTypeTemplates> IngredientType { get; set; }
    }
    public class CreateTemplateRequestValidator : AbstractValidator<CreateTemplateRequest>
    {
        public CreateTemplateRequestValidator()
        {
            RuleFor(x => x.TemplateStepId)
                .NotEmpty().WithMessage("TemplateStepId is required.")
                .GreaterThan(0).WithMessage("TemplateStepId must be greater than 0.");

            RuleForEach(x => x.IngredientType)
                .SetValidator(new IngredientTypeTemplateStepsValidator());
        }
    }
}
