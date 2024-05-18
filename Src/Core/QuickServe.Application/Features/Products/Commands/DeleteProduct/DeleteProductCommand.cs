using MediatR;
using QuickServe.Application.Wrappers;

namespace QuickServe.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<BaseResult>
    {
        public long Id { get; set; }
    }
}
