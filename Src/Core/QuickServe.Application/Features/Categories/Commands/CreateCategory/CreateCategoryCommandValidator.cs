using FluentValidation;
using QuickServe.Application.Interfaces;

namespace QuickServe.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator(ITranslator translator)
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(translator["Tên là bắt buộc"])
            .NotNull().WithMessage(translator["Tên là bắt buộc"])
            .MaximumLength(40).WithMessage(translator["Tên không được vượt quá 40 ký tự"])
            .Must(name => char.IsUpper(name[0])).WithMessage(translator["Chữ cái đầu tiên của tên phải là chữ in hoa"])
            .WithName(p => translator[nameof(p.Name)]);
    }
}