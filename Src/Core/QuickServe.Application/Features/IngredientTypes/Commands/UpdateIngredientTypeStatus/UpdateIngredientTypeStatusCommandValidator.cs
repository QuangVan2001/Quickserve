using FluentValidation;
using QuickServe.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.Features.IngredientTypes.Commands.UpdateIngredientTypeStatus
{
    public class UpdateIngredientTypeStatusCommandValidator : AbstractValidator<UpdateIngredientTypeStatusCommand>
    {
        public UpdateIngredientTypeStatusCommandValidator(ITranslator translator)
        {
            RuleFor(p => p.Id)
          .NotNull().WithMessage(translator["Id là bắt buộc"])
          .NotEmpty().WithMessage(translator["Id là bắt buộc"])
          .WithName(p => translator[nameof(p.Id)]);
        }
    }
}
