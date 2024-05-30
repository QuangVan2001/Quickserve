using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuickServe.Application.Features.IngredientTypes.Commands.CreateIngredientType;
using QuickServe.Application.Features.IngredientTypes.Commands.DeleteIngredientType;
using QuickServe.Application.Features.IngredientTypes.Commands.UpdateIngredientType;
using QuickServe.Application.Features.IngredientTypes.Commands.UpdateIngredientTypeStatus;
using QuickServe.Application.Features.IngredientTypes.Queries.GetIngredientTypeById;
using QuickServe.Application.Features.IngredientTypes.Queries.GetPagedListIngredientType;
using QuickServe.Application.Features.IngredientTypes.Queries.GetPagedListIngredientTypeByActiveStatus;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.IngredientTypes.Dtos;
using System.Threading.Tasks;

namespace QuickServe.WebApi.Controllers.v1
{
    public class IngredientTypeController : BaseApiController
    {
        [HttpGet]
        public async Task<PagedResponse<IngredientTypeDTO>> GetPagedListIngredientType([FromQuery] GetPagedListIngredientTypeQuery model)
            => await Mediator.Send(model);
        [HttpGet]
        public async Task<PagedResponse<IngredientTypeDTO>> GetPagedListByActiveStatus([FromQuery] GetPagedListIngredientTypeByActiveStatusQuery model)
          => await Mediator.Send(model);

        [HttpGet]
        public async Task<BaseResult<IngredientTypeDTO>> GetIngredientTypeById([FromQuery] GetIngredientTypeByIdQuery model)
            => await Mediator.Send(model);

        [HttpPost, Authorize]
        public async Task<BaseResult> CreateIngredientType(CreateIngredientTypeCommand model)
            => await Mediator.Send(model);

        [HttpPut, Authorize]
        public async Task<BaseResult> UpdateIngredientType(UpdateIngredientTypeCommand model)
            => await Mediator.Send(model);

        [HttpPut, Authorize]
        public async Task<BaseResult> UpdateIngredientTypeStatus(UpdateIngredientTypeStatusCommand model)
            => await Mediator.Send(model);

        [HttpDelete]
        public async Task<BaseResult> DeleteIngredientType([FromQuery] DeleteIngredientTypeCommand model)
            => await Mediator.Send(model);
    }
}