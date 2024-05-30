using MediatR;
using QuickServe.Application.Features.IngredientTypes.Queries.GetPagedListIngredientTypeByActiveStatus;
using QuickServe.Application.Interfaces.Repositories;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Ingredients.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuickServe.Application.Features.Ingredients.Queries.GetPagedListIngredientByActiveStatus
{
    public class GetPagedListIngredientByActiveStatusQueryHandler(IIngredientRepository ingredientRepository) : IRequestHandler<GetPagedListIngredientByActiveStatusQuery, PagedResponse<IngredientDTO>>
    {
        public async Task<PagedResponse<IngredientDTO>> Handle(GetPagedListIngredientByActiveStatusQuery request, CancellationToken cancellationToken)
        {
            var result = await ingredientRepository.GetPagedListByAcitveStatusAsync(request.PageNumber, request.PageSize, request.Name);
            return new PagedResponse<IngredientDTO>(result, request);
        }
    }
}