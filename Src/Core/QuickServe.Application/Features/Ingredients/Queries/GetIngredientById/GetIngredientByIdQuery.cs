using MediatR;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Categories.Dtos;
using QuickServe.Domain.Ingredients.Dtos;

namespace QuickServe.Application.Features.Ingredients.Queries.GetIngredientById;

public class GetIngredientByIdQuery : IRequest<BaseResult<IngredientDTO>>
{
    public long Id { get; set; }
}