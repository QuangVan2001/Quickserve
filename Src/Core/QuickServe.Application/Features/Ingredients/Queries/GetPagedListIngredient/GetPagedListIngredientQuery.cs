using MediatR;
using QuickServe.Application.Parameters;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Ingredients.Dtos;

namespace QuickServe.Application.Features.Ingredients.Queries.GetPagedListIngredient;

public class GetPagedListIngredientQuery : PagenationRequestParameter, IRequest<PagedResponse<IngredientDTO>>
{
    public string Name { get; set; }
}