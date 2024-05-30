using MediatR;
using QuickServe.Application.Wrappers;

namespace QuickServe.Application.Features.Ingredients.Commands.DeleteIngredient;

public class DeleteIngredientCommand : IRequest<BaseResult>
{
    public long Id { get; set; }
}