using FluentValidation;
using QuickServe.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.Features.Ingredients.Commands.DeleteIngredient
{
    public class DeleteIngredientCommandValidator : AbstractValidator<DeleteIngredientCommand>
    {
        public DeleteIngredientCommandValidator(ITranslator translator)
        {
            RuleFor(p => p.Id)
                    .NotNull()
                    .NotEmpty()
                    .GreaterThan(0)
                    .WithName(p => translator[nameof(p.Id)]);
        }
    }
}
