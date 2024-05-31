using FluentValidation;
using QuickServe.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.Features.TemplateSteps.Commands.UpdateTemplateStep
{
    public class UpdateTemplateStepCommandValidator : AbstractValidator<UpdateTemplateStepCommand>
    {
        public UpdateTemplateStepCommandValidator(ITranslator translator)
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(1, 40).WithMessage("Name must be between 1 and 40 characters.");

        }
    }
}
