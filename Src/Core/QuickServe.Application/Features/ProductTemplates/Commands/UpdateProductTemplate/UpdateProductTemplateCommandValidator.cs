using FluentValidation;
using QuickServe.Application.Features.Ingredients.Commands.UpdateIngredient;
using QuickServe.Application.Interfaces;

namespace QuickServe.Application.Features.ProductTemplates.Commands.UpdateProductTemplate;

public class UpdateProductTemplateCommandValidator : AbstractValidator<UpdateProductTemplateCommand>
{
    public UpdateProductTemplateCommandValidator(ITranslator translator)
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


        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage(translator["Price must be greater than 0."]);

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage(translator["Description is required."])
            .MaximumLength(200).WithMessage(translator["Description cannot exceed 200 characters."]);

        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage(translator["CategoryId must be greater than 0."]);

        RuleFor(x => x.Size)
            .NotEmpty()
            .NotNull()
            .MaximumLength(10).WithMessage(translator["Size must not exceed 10 characters."]);
    }
}