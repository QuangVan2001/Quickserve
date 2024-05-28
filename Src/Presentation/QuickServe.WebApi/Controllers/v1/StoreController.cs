using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuickServe.Application.DTOs.Account.Responses;
using QuickServe.Application.Features.Store.Commands.CreateStore;
using QuickServe.Application.Features.Store.Commands.DeleteStore;
using QuickServe.Application.Features.Store.Commands.UpdateStore;
using QuickServe.Application.Features.Store.Queries.GetPagedListStore;
using QuickServe.Application.Features.Store.Queries.GetStoreById;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Stores.Dtos;

namespace QuickServe.WebApi.Controllers.v1;
//[ApiVersion("1")]
public class StoreController : BaseApiController
{
    [HttpGet]
    public async Task<PagedResponse<StoreDto>> GetPagedListStore([FromQuery] GetPagedListStoreQuery model)
        => await Mediator.Send(model);

    [HttpGet]
    public async Task<BaseResult<StoreDto>> GetStoreById([FromQuery] GetStoreByIdQuery model)
        => await Mediator.Send(model);
    
    [HttpPost, Authorize]
    public async Task<BaseResult<long>> CreateStore(CreateStoreCommand model)
        => await Mediator.Send(model);

    [HttpPut, Authorize]
    public async Task<BaseResult> UpdateStore(UpdateStoreCommand model)
        => await Mediator.Send(model);

    [HttpDelete, Authorize]
    public async Task<BaseResult> DeleteStore([FromQuery] DeleteStoreCommand model)
        => await Mediator.Send(model);
}