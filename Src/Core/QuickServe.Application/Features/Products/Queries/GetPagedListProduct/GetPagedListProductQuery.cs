using MediatR;
using QuickServe.Application.Parameters;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Products.Dtos;

namespace QuickServe.Application.Features.Products.Queries.GetPagedListProduct
{
    public class GetPagedListProductQuery : PagenationRequestParameter, IRequest<PagedResponse<ProductDto>>
    {
        public string Name { get; set; }
    }


}
