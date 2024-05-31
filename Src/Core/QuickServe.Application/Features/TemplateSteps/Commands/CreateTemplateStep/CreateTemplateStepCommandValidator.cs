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
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(translator["Name is required."])
                .Length(2, 40).WithMessage(translator["Name must be between 2 and 40 characters."]);
            RuleFor(x => x.ProductTemplateId)
                .NotEmpty().WithMessage(translator["ProductTemplateId is required."])
                .GreaterThan(0).WithMessage(translator["ProductTemplateId must be greater than 0."]);
        }
    }
}
