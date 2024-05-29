using FluentValidation;
using QuickServe.Application.Interfaces;

namespace QuickServe.Application.Features.IngredientTypes.Commands.UpdateIngredientType;

public class UpdateIngredientTypeCommandValidator : AbstractValidator<UpdateIngredientTypeCommand>
{
    public UpdateIngredientTypeCommandValidator(ITranslator translator)
    {
        RuleFor(x => x.Name)
                .NotEmpty().WithMessage(translator["Name is required"])
                .NotNull().WithMessage(translator["Name is required"])
                .MaximumLength(40).WithMessage(translator["Name must not exceed 40 characters"])
                .Must(name => char.IsUpper(name[0])).WithMessage(translator["First letter of Name must be uppercase"])
                .WithName(p => translator[nameof(p.Name)]);

        RuleFor(p => p.Id)
                .NotNull().WithMessage(translator["Id is required"])
                .NotEmpty().WithMessage(translator["Id is required"])
                .WithName(p => translator[nameof(p.Id)]);
    }
}