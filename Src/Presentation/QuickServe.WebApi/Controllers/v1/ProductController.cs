using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuickServe.Application.Features.Products.Commands.CreateProduct;
using QuickServe.Application.Features.Products.Commands.DeleteProduct;
using QuickServe.Application.Features.Products.Commands.UpdateProduct;
using QuickServe.Application.Features.Products.Queries.GetPagedListProduct;
using QuickServe.Application.Features.Products.Queries.GetProductById;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Products.Dtos;
using System.Threading.Tasks;

namespace QuickServe.WebApi.Controllers.v1
{
    [ApiVersion("1")]
    public class ProductController : BaseApiController
    {

        [HttpGet]
        public async Task<PagedResponse<ProductDto>> GetPagedListProduct([FromQuery] GetPagedListProductQuery model)
            => await Mediator.Send(model);

        [HttpGet]
        public async Task<BaseResult<ProductDto>> GetProductById([FromQuery] GetProductByIdQuery model)
            => await Mediator.Send(model);

        [HttpPost, Authorize]
        public async Task<BaseResult<long>> CreateProduct(CreateProductCommand model)
            => await Mediator.Send(model);

        [HttpPut, Authorize]
        public async Task<BaseResult> UpdateProduct(UpdateProductCommand model)
            => await Mediator.Send(model);

        [HttpDelete, Authorize]
        public async Task<BaseResult> DeleteProduct([FromQuery] DeleteProductCommand model)
            => await Mediator.Send(model);

    }
}