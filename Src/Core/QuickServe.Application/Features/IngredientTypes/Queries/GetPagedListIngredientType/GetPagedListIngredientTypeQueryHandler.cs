using MediatR;
using QuickServe.Application.Features.Categories.Queries.GetPagedListCategory;
using QuickServe.Application.Interfaces.Repositories;
using QuickServe.Application.Wrappers;
using System.Threading.Tasks;
using System.Threading;
using QuickServe.Domain.IngredientTypes.Dtos;

namespace QuickServe.Application.Features.IngredientTypes.Queries.GetPagedListIngredientType;

public class GetPagedListIngredientTypeQueryHandler(IIngredientTypeRepository ingredientTypeRepository) : IRequestHandler<GetPagedListIngredientTypeQuery, PagedResponse<IngredientTypeDTO>>
{
    public async Task<PagedResponse<IngredientTypeDTO>> Handle(GetPagedListIngredientTypeQuery request, CancellationToken cancellationToken)
    {
        var result = await ingredientTypeRepository.GetPagedListAsync(request.PageNumber, request.PageSize, request.Name);
        return new PagedResponse<IngredientTypeDTO>(result, request);
    }
}