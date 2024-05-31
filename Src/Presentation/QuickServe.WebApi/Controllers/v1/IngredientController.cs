using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuickServe.Application.DTOs.Ingredients.Request;
using QuickServe.Application.Features.Ingredients.Commands.DeleteIngredient;
using QuickServe.Application.Features.Ingredients.Commands.UpdateIngredient;
using QuickServe.Application.Features.Ingredients.Queries.GetIngredientById;
using QuickServe.Application.Features.Ingredients.Queries.GetPagedListIngredient;
using QuickServe.Application.Features.Ingredients.Queries.GetPagedListIngredientByActiveStatus;
using QuickServe.Application.Interfaces.IngredientInterfaces;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Ingredients.Dtos;
using System.Threading.Tasks;

namespace QuickServe.WebApi.Controllers.v1
{
    public class IngredientController : BaseApiController
    {
        private readonly IIngredientService _IngredientService;
        public IngredientController(IIngredientService IngredientService)
        {
            _IngredientService = IngredientService;
        }
        [HttpGet]
        public async Task<PagedResponse<IngredientDTO>> GetPagedListIngredient([FromQuery] GetPagedListIngredientQuery model)
        => await Mediator.Send(model);
        [HttpGet]
        public async Task<PagedResponse<IngredientDTO>> GetPagedListByActiveStatus([FromQuery] GetPagedListIngredientByActiveStatusQuery model)
         => await Mediator.Send(model);
        [HttpGet]
        public async Task<BaseResult<IngredientDTO>> GetCategoryById([FromQuery] GetIngredientByIdQuery model)
        => await Mediator.Send(model);
        [HttpPost, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Brand_Manager")]
        public async Task<BaseResult> CreateIngredient([FromForm] CreateIngredientRequest request)
           => await _IngredientService.CreateIngredientAsync(request);

        [HttpPut, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Brand_Manager")]
        public async Task<BaseResult> UpdateIngredient(UpdateIngredientCommand model)
        => await Mediator.Send(model);

        [HttpPut, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Brand_Manager")]
        public async Task<BaseResult> UpdateIngredientImage([FromQuery]int id, [FromForm] UpdateIngredientImageRequest request)
           => await _IngredientService.UpdateIngredientImageAsync(id, request);

        [HttpDelete, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Brand_Manager")]
        public async Task<BaseResult> DeleteIngredient([FromQuery] DeleteIngredientCommand model)
    => await Mediator.Send(model);
    }
}
