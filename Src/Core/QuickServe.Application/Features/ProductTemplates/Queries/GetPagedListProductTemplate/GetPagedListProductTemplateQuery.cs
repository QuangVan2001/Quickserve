using MediatR;
using QuickServe.Application.Parameters;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.ProductTemplates.Dtos;

namespace QuickServe.Application.Features.ProductTemplates.Queries.GetPagedListProductTemplate;

public class GetPagedListProductTemplateQuery : PagenationRequestParameter, IRequest<PagedResponse<ProductTemplateDto>>
{
    public string Name { get; set; }
}