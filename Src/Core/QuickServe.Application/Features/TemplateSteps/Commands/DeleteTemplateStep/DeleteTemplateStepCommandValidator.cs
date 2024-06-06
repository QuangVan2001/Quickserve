using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.Features.TemplateSteps.Commands.DeleteTemplateStep
{
    public class DeleteTemplateStepCommandValidator : AbstractValidator<DeleteTemplateStepCommand>
    {
        public DeleteTemplateStepCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("Id là bắt buộc.")
                .GreaterThan(0).WithMessage("Id phải lớn hơn 0.");
        }
    }
}
