using MediatR;
using QuickServe.Application.Features.Categories.Queries.GetPagedListCategory;
using QuickServe.Application.Interfaces.Repositories;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Categories.Dtos;
using System.Threading.Tasks;
using System.Threading;
using QuickServe.Domain.Ingredients.Dtos;

namespace QuickServe.Application.Features.Ingredients.Queries.GetPagedListIngredient;

public class GetPagedListIngredientQueryHandler(IIngredientRepository ingredientRepository) : IRequestHandler<GetPagedListIngredientQuery, PagedResponse<IngredientDTO>>
{
    public async Task<PagedResponse<IngredientDTO>> Handle(GetPagedListIngredientQuery request, CancellationToken cancellationToken)
    {
        var result = await ingredientRepository.GetPagedListAsync(request.PageNumber, request.PageSize, request.Name);
        return new PagedResponse<IngredientDTO>(result, request);
    }
}