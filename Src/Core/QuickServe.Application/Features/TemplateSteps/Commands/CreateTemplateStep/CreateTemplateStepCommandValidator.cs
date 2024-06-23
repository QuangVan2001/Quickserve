using FluentValidation;
using QuickServe.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.Features.TemplateSteps.Commands.CreateTemplateStep
{
    public class CreateTemplateStepCommandValidator : AbstractValidator<CreateTemplateStepCommand>
    {
        public CreateTemplateStepCommandValidator(ITranslator translator)
        {

            RuleFor(x => x.ProductTemplateId)
                .NotEmpty().WithMessage(translator["ProductTemplateId là bắt buộc."])
                .GreaterThan(0).WithMessage(translator["ProductTemplateId phải lớn hơn 0."]);
            RuleFor(x => x.TemplateSteps)
              .Must(ingredientTypes => ingredientTypes.Select(i => i.Name).Distinct().Count() == ingredientTypes.Count)
              .WithMessage("Mỗi bước chỉ được xuất hiện một lần.");
        }
    }
}
