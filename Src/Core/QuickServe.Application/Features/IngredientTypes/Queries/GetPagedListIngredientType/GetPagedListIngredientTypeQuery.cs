using MediatR;
using QuickServe.Application.Parameters;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.IngredientTypes.Dtos;

namespace QuickServe.Application.Features.IngredientTypes.Queries.GetPagedListIngredientType;

public class GetPagedListIngredientTypeQuery : PagenationRequestParameter, IRequest<PagedResponse<IngredientTypeDTO>>
{
    public string Name { get; set; }
}