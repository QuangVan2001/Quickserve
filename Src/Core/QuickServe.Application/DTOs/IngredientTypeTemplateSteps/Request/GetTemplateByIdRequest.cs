using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.DTOs.IngredientTypeTemplateSteps.Request
{
    public class GetTemplateByIdRequest
    {
        public long TemplateStepId { get; set; }
    }
    public class GetTemplateByIdRequestValidator : AbstractValidator<GetTemplateByIdRequest>
    {
        public GetTemplateByIdRequestValidator()
        {
            RuleFor(x => x.TemplateStepId)
                .NotEmpty().WithMessage("TemplateStepId is required.")
                .GreaterThan(0).WithMessage("TemplateStepId must be greater than 0.");
        }
    }
}
