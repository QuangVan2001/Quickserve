using FluentValidation;
using QuickServe.Application.Features.IngredientTypes.Commands.DeleteIngredientType;
using QuickServe.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.Features.ProductTemplates.Commands.DeleteProductTemplate
{
    public class DeleteProductTemplateCommandValidator : AbstractValidator<DeleteProductTemplateCommand>
    {
        public DeleteProductTemplateCommandValidator(ITranslator translator)
        {
            RuleFor(p => p.Id)
                    .NotNull()
                    .NotEmpty()
                    .WithName(p => translator[nameof(p.Id)]);
        }
    }
}