using MediatR;
using QuickServe.Application.Wrappers;

namespace QuickServe.Application.Features.IngredientTypes.Commands.CreateIngredientType;

public class CreateIngredientTypeCommand : IRequest<BaseResult>
{
    public string Name { get; set; }

}