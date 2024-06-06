using MediatR;
using QuickServe.Application.Features.Categories.Queries.GetPagedListCategory;
using QuickServe.Application.Interfaces.Repositories;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Categories.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuickServe.Application.Features.Categories.Queries.GetPagedListCategoryByActiveStatus
{
    public class GetPagedListCategoryByActiveStatusQueryHandler(ICategoryRepository categoryRepository) : IRequestHandler<GetPagedListCategoryByActiveStatusQuery, PagedResponse<CategoryDto>>
    {
        public async Task<PagedResponse<CategoryDto>> Handle(GetPagedListCategoryByActiveStatusQuery request, CancellationToken cancellationToken)
        {
            var result = await categoryRepository.GetPagedListByAcitveStatusAsync(request.PageNumber, request.PageSize, request.Name);
            return new PagedResponse<CategoryDto>(result, request);
        }
    }
}
