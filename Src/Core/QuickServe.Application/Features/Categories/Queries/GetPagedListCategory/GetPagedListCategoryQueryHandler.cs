using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QuickServe.Application.Interfaces.Repositories;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Categories.Dtos;

namespace QuickServe.Application.Features.Categories.Queries.GetPagedListCategory;

public class GetPagedListCategoryQueryHandler(ICategoryRepository categoryRepository): IRequestHandler<GetPagedListCategoryQuery, PagedResponse<CategoryDto>>
{
    public async Task<PagedResponse<CategoryDto>> Handle(GetPagedListCategoryQuery request, CancellationToken cancellationToken)
    {
        var result = await categoryRepository.GetPagedListAsync(request.PageNumber, request.PageSize, request.Name);
        return new PagedResponse<CategoryDto>(result, request);
    }
}

