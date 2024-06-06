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
               .NotEmpty().WithMessage("Id là bắt buộc.")
               .GreaterThan(0).WithMessage("Id phải lớn hơn 0.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Tên là bắt buộc.")
                .Length(1, 40).WithMessage("Tên phải từ 1 đến 40 ký tự.");
        }
    }
}
