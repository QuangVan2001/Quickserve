using MediatR;
using QuickServe.Application.Wrappers;

namespace QuickServe.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<BaseResult>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string BarCode { get; set; }
    }
}
