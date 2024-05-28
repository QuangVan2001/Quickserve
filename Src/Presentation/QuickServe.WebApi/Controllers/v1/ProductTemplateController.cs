using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuickServe.Application.Features.ProductTemplates.Queries.GetPagedListProductTemplate;
using QuickServe.Application.Features.ProductTemplates.Queries.GetProductTemplateById;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.ProductTemplates.Dtos;

namespace QuickServe.WebApi.Controllers.v1;
//[ApiVersion("1")]
public class ProductTemplateController : BaseApiController
{
    [HttpGet]
    public async Task<PagedResponse<ProductTemplateDto>> GetPagedListProductTemplate(
        [FromQuery] GetPagedListProductTemplateQuery model)
        => await Mediator.Send(model);
    
    [HttpGet]
    public async Task<BaseResult<ProductTemplateDto>> GetProductById([FromQuery] GetProductTemplateByIdQuery model)
        => await Mediator.Send(model);
}

