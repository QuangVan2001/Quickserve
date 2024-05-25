using MediatR;
using QuickServe.Application.Parameters;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Categories.Dtos;
using QuickServe.Domain.Stores.Dtos;

namespace QuickServe.Application.Features.Categories.Queries.GetPagedListCategory;

public class GetPagedListCategoryQuery : PagenationRequestParameter, IRequest<PagedResponse<CategoryDto>>
{
    public string Name { get; set; }
}