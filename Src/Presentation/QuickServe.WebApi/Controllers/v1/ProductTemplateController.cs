using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuickServe.Application.DTOs.ProductTemplates;
using QuickServe.Application.Features.IngredientTypes.Commands.UpdateIngredientType;
using QuickServe.Application.Features.ProductTemplates.Commands.DeleteProductTemplate;
using QuickServe.Application.Features.ProductTemplates.Commands.UpdateProductTemplate;
using QuickServe.Application.Features.ProductTemplates.Queries.GetPagedListProductTemplate;
using QuickServe.Application.Features.ProductTemplates.Queries.GetPagedListProductTemplateByActiveStatus;
using QuickServe.Application.Features.ProductTemplates.Queries.GetProductTemplateById;
using QuickServe.Application.Interfaces.IProductTemplateServices;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.ProductTemplates.Dtos;

namespace QuickServe.WebApi.Controllers.v1;
[ApiVersion("1")]
public class ProductTemplateController : BaseApiController
{
    private readonly IProductTemplateService _productTemplateService;
    public ProductTemplateController(IProductTemplateService productTemplateService)
    {
        _productTemplateService = productTemplateService;
    }
    [HttpGet]
    public async Task<PagedResponse<ProductTemplateDto>> GetPagedListProductTemplate(
        [FromQuery] GetPagedListProductTemplateQuery model)
        => await Mediator.Send(model);

    [HttpGet]
    public async Task<PagedResponse<ProductTemplateDto>> GetPagedListProductTemplateByActiveStatus(
        [FromQuery] GetPagedListProductTemplateByActiveStatusQuery model)
        => await Mediator.Send(model);

    [HttpGet]
    public async Task<BaseResult<ProductTemplateDto>> GetProductTemplateById([FromQuery] GetProductTemplateByIdQuery model)
        => await Mediator.Send(model);

    [HttpPost, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Brand_Manager")]
    public async Task<BaseResult> CreateProductTemplate([FromForm] CreateProductTemplateRequest request)
          => await _productTemplateService.CreateProductTemplateAsync(request);
    [HttpPut, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Brand_Manager")]
    public async Task<BaseResult> UpdateProductTemplate(UpdateProductTemplateCommand model)
           => await Mediator.Send(model);

    [HttpPut, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Brand_Manager")]
    public async Task<BaseResult> UpdateProductTemplateImage([FromQuery] int id, [FromForm] UpdateProductTemplateImageRequest request)
           => await _productTemplateService.UpdateProductTemplateImageAsync(id, request);

    [HttpDelete, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Brand_Manager")]
    public async Task<BaseResult> DeleteProductTemplate([FromQuery] DeleteProductTemplateCommand model)
            => await Mediator.Send(model);
}

