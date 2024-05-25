using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuickServe.Application.Features.Categories.Commands.CreateCategory;
using QuickServe.Application.Features.Categories.Commands.DeleteCategory;
using QuickServe.Application.Features.Categories.Commands.UpdateCategory;
using QuickServe.Application.Features.Categories.Queries.GetCategoryById;
using QuickServe.Application.Features.Categories.Queries.GetPagedListCategory;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Categories.Dtos;

namespace QuickServe.WebApi.Controllers.v1;

public class CategoryController : BaseApiController
{
    [HttpGet]
    public async Task<PagedResponse<CategoryDto>> GetPagedListCategory([FromQuery] GetPagedListCategoryQuery model)
        => await Mediator.Send(model);

    [HttpGet]
    public async Task<BaseResult<CategoryDto>> GetCategoryById([FromQuery] GetCategoryByIdQuery model)
        => await Mediator.Send(model);
    
    [HttpPost, Authorize]
    public async Task<BaseResult<long>> CreateCategory(CreateCategoryCommand model)
        => await Mediator.Send(model);

    [HttpPut, Authorize]
    public async Task<BaseResult> UpdateCategory(UpdateCategoryCommand model)
        => await Mediator.Send(model);

    [HttpDelete]
    public async Task<BaseResult> DeleteCategory([FromQuery] DeleteCategoryCommand model)
        => await Mediator.Send(model);
}