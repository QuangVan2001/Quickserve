using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuickServe.Application.DTOs.Ingredients.Request;
using QuickServe.Application.DTOs.IngredientTypeTemplateSteps.Request;
using QuickServe.Application.DTOs.ProductTemplates.Request;
using QuickServe.Application.Features.Ingredients.Commands.DeleteIngredient;
using QuickServe.Application.Features.Ingredients.Commands.UpdateIngredient;
using QuickServe.Application.Features.Ingredients.Queries.GetPagedListIngredient;
using QuickServe.Application.Features.Ingredients.Queries.GetPagedListIngredientByActiveStatus;
using QuickServe.Application.Interfaces.IngredientInterfaces;
using QuickServe.Application.Interfaces.IngredientTypeTemplateSteps;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Ingredients.Dtos;
using QuickServe.Infrastructure.Persistence.Services;
using System.Threading.Tasks;

namespace QuickServe.WebApi.Controllers.v1
{
    public class IngredientTypeTemplateStepController : BaseApiController
    {
        private readonly IIngredientTypeTemplateStepService _service;
        public IngredientTypeTemplateStepController(IIngredientTypeTemplateStepService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<BaseResult> GetAll([FromQuery] GetAllTemplateRequest model)
        => await _service.GetAll(model);
        [HttpGet]
        public async Task<BaseResult> GetTemplateById([FromQuery] GetTemplateByIdRequest model)
         => await _service.GetById(model);
        
        [HttpPost, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Brand_Manager")]
        public async Task<BaseResult> CreateTemplate(CreateTemplateRequest request)
          => await _service.CreateTempalte(request);

        [HttpPut, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Brand_Manager")]
        public async Task<BaseResult> UpdateTemplate(CreateTemplateRequest request)
        => await _service.UpdateTempalte(request);
        [HttpPut, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Brand_Manager")]
        public async Task<BaseResult> UpdateTemplateStatus(UpdateTemplateStatusRequest request)
       => await _service.UpdateTemplateStatus(request);

        [HttpDelete, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Brand_Manager")]
        public async Task<BaseResult> DeleteIngredient([FromQuery] DeleteTemplateRequest model)
        => await _service.DeleteTemplate(model);
    }
}
