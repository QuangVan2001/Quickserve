using FluentValidation;
using QuickServe.Application.Interfaces;

namespace QuickServe.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator(ITranslator translator)
    {
        RuleFor(p => p.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(40)
            .WithName(p => translator[nameof(p.Name)]);

    }
}