using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QuickServe.Application.Interfaces.Repositories;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.ProductTemplates.Dtos;

namespace QuickServe.Application.Features.ProductTemplates.Queries.GetPagedListProductTemplate;

public class GetPagedListProductTemplateQueryHandler(IProductTemplateRepository productTemplateRepository) : IRequestHandler<GetPagedListProductTemplateQuery, PagedResponse<ProductTemplateDto>>
{
    public async Task<PagedResponse<ProductTemplateDto>> Handle(GetPagedListProductTemplateQuery request, CancellationToken cancellationToken)
    {
        var result = await productTemplateRepository.GetPagedListAsync(request.PageNumber, request.PageSize, request.Name);

        return new PagedResponse<ProductTemplateDto>(result, request);
    }
}