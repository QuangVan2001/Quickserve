using FluentValidation;
using QuickServe.Application.Interfaces;

namespace QuickServe.Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandValidator :  AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator(ITranslator translator)
    {
        RuleFor(p => p.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(40)
            .WithName(p => translator[nameof(p.Name)]);

        RuleFor(p => p.Id)
                .NotNull()
                .NotEmpty()
                .WithName(p => translator[nameof(p.Id)]);
    }
}