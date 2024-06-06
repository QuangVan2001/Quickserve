using FluentValidation;
using QuickServe.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.Features.Categories.Commands.UpdateCategoryStatus
{
    public class UpdateCategoryCommandValidator :  AbstractValidator<UpdateCategoryStatusCommand>{
        public UpdateCategoryCommandValidator(ITranslator translator){
            RuleFor(p => p.Id)
                 .NotNull().WithMessage(translator["Id là bắt buộc"])
                 .NotEmpty().WithMessage(translator["Id là bắt buộc"])
                 .WithName(p => translator[nameof(p.Id)]);
        }
    }
}
