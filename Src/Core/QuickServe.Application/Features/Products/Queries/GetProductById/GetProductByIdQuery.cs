using MediatR;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Products.Dtos;

namespace QuickServe.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<BaseResult<ProductDto>>
    {
        public long Id { get; set; }
    }

    
}
