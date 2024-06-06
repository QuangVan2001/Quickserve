using MediatR;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.IngredientTypes.Dtos;

namespace QuickServe.Application.Features.IngredientTypes.Queries.GetIngredientTypeById;

public class GetIngredientTypeByIdQuery : IRequest<BaseResult<IngredientTypeDTO>>
{
    public long Id { get; set; }
}