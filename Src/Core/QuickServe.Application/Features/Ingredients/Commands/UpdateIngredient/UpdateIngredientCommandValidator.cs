using FluentValidation;
using QuickServe.Application.Features.Categories.Commands.UpdateCategory;
using QuickServe.Application.Interfaces;

namespace QuickServe.Application.Features.Ingredients.Commands.UpdateIngredient;

public class UpdateIngredientCommandValidator : AbstractValidator<UpdateIngredientCommand>
{
    public UpdateIngredientCommandValidator(ITranslator translator)
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

        RuleFor(p => p.Price)
            .GreaterThan(0).WithMessage(translator["Price must be greater than 0"])
            .WithName(p => translator[nameof(p.Price)]);

        RuleFor(p => p.Calo)
            .GreaterThanOrEqualTo(0).WithMessage(translator["Calo must be greater than or equal to 0"])
            .WithName(p => translator[nameof(p.Calo)]);

        RuleFor(p => p.Description)
            .NotEmpty().WithMessage(translator["Description is required"])
            .MaximumLength(200).WithMessage(translator["Description cannot exceed 200 characters"])
            .WithName(p => translator[nameof(p.Description)]);

        RuleFor(p => p.IngredientTypeId)
            .GreaterThan(0).WithMessage(translator["IngredientTypeId must be greater than 0"])
            .WithName(p => translator[nameof(p.IngredientTypeId)]);
    }
}