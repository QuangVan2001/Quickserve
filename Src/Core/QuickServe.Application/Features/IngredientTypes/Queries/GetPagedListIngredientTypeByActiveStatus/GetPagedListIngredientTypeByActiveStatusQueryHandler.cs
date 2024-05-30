using MediatR;
using QuickServe.Application.Features.Categories.Queries.GetPagedListCategoryByActiveStatus;
using QuickServe.Application.Interfaces.Repositories;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Categories.Dtos;
using QuickServe.Domain.IngredientTypes.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuickServe.Application.Features.IngredientTypes.Queries.GetPagedListIngredientTypeByActiveStatus
{
    public class GetPagedListIngredientTypeByActiveStatusQueryHandler(IIngredientTypeRepository ingredientTypeRepository) : IRequestHandler<GetPagedListIngredientTypeByActiveStatusQuery, PagedResponse<IngredientTypeDTO>>
    {
        public async Task<PagedResponse<IngredientTypeDTO>> Handle(GetPagedListIngredientTypeByActiveStatusQuery request, CancellationToken cancellationToken)
        {
            var result = await ingredientTypeRepository.GetPagedListByAcitveStatusAsync(request.PageNumber, request.PageSize, request.Name);
            return new PagedResponse<IngredientTypeDTO>(result, request);
        }
    }
}