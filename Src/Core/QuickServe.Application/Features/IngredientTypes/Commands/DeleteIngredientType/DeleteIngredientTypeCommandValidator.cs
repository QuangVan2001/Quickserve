using FluentValidation;
using QuickServe.Application.Features.Categories.Commands.DeleteCategory;
using QuickServe.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.Features.IngredientTypes.Commands.DeleteIngredientType
{
    public class DeleteIngredientTypeCommandValidator : AbstractValidator<DeleteIngredientTypeCommand>
    {
        public DeleteIngredientTypeCommandValidator(ITranslator translator)
        {
            RuleFor(p => p.Id)
                    .NotNull()
                    .NotEmpty()
                    .WithName(p => translator[nameof(p.Id)]);
        }
    }
}