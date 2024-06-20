using FluentValidation;

namespace QuickServe.Application.Features.Orders.Commands.CreateOrder;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage("CustomerId là bắt buộc.");

        RuleFor(x => x.StoreId)
            .NotEmpty().WithMessage("StoreId là bắt buộc.");

        RuleFor(x => x.Products)
            .NotEmpty().WithMessage("Products là bắt buộc.");
    }
}
