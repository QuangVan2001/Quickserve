using FluentValidation;
using QuickServe.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.Features.Ingredients.Commands.UpdateIngredientStatus
{
    public class UpdateIngredientStatusCommandValidator : AbstractValidator<UpdateIngredientStatusCommand>
    {
        public UpdateIngredientStatusCommandValidator(ITranslator translator)
        {
            RuleFor(p => p.Id)
                    .NotNull()
                    .NotEmpty()
                    .WithName(p => translator[nameof(p.Id)]);
        }
    }
}
