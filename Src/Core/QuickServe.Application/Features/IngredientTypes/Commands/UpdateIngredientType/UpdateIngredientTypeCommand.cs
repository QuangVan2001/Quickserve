using MediatR;
using QuickServe.Application.Wrappers;

namespace QuickServe.Application.Features.IngredientTypes.Commands.UpdateIngredientType;

public class UpdateIngredientTypeCommand : IRequest<BaseResult>
{
    public long Id { get; set; }
    public string Name { get; set; }
}