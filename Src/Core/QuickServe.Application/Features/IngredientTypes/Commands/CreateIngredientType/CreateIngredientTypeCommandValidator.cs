using FluentValidation;
using QuickServe.Application.Interfaces;

namespace QuickServe.Application.Features.IngredientTypes.Commands.CreateIngredientType;

public class CreateIngredientTypeCommandValidator : AbstractValidator<CreateIngredientTypeCommand>
{
    public CreateIngredientTypeCommandValidator(ITranslator translator)
    {
        RuleFor(x => x.Name)
                .NotEmpty().WithMessage(translator["Name is required"])
                .NotNull().WithMessage(translator["Name is required"])
                .MaximumLength(40).WithMessage(translator["Name must not exceed 40 characters"])
                .Must(name => char.IsUpper(name[0])).WithMessage(translator["First letter of Name must be uppercase"])
                .WithName(p => translator[nameof(p.Name)]);

    }
}