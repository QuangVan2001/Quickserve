using FluentValidation;
using QuickServe.Application.Features.Categories.Commands.UpdateCategory;
using QuickServe.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.Features.Categories.Commands.UpdateCategoryStatus
{
    public class UpdateCategoryCommandValidator :  AbstractValidator<UpdateCategoryCommand>{
        public UpdateCategoryCommandValidator(ITranslator translator){
        RuleFor(p => p.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(40)
            .WithName(p => translator[nameof(p.Name)]);

        RuleFor(p => p.Id)
                .NotNull()
                .NotEmpty()
                .WithName(p => translator[nameof(p.Id)]);
        }
    }
}
