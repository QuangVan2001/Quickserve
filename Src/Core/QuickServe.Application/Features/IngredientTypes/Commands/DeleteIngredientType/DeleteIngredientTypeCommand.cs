using MediatR;
using QuickServe.Application.Wrappers;

namespace QuickServe.Application.Features.IngredientTypes.Commands.DeleteIngredientType;

public class DeleteIngredientTypeCommand : IRequest<BaseResult>
{
    public long Id { get; set; }
}