using FluentValidation;
using QuickServe.Application.Interfaces;
using QuickServe.Domain.Stores.Dtos;

namespace QuickServe.Application.Features.Store.Commands.UpdateStore;

public class UpdateStoreCommandValidator : AbstractValidator<UpdateStoreCommand>
{
    public UpdateStoreCommandValidator(ITranslator translator)
    {
        RuleFor(s => s.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(50)
            .WithName(s => translator[nameof(s.Name)]);
        
        RuleFor(s => s.Address)
            .NotNull()
            .NotEmpty()
            .MaximumLength(50)
            .WithName(p => translator[nameof(p.Address)]);
    }
}