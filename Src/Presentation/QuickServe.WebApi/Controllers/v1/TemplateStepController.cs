using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuickServe.Application.Features.TemplateSteps.Commands.CreateTemplateStep;
using QuickServe.Application.Features.TemplateSteps.Commands.DeleteTemplateStep;
using QuickServe.Application.Features.TemplateSteps.Commands.UpdateTemplateStep;
using QuickServe.Application.Features.TemplateSteps.Queries.GetPagedListTemplateStep;
using QuickServe.Application.Features.TemplateSteps.Queries.GetPagedListTemplateStepByActiveStatus;
using QuickServe.Application.Features.TemplateSteps.Queries.GetTemplateStepById;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.TemplateSteps.Dtos;
using System.Threading.Tasks;

namespace QuickServe.WebApi.Controllers.v1
{
    public class TemplateStepController : BaseApiController
    {
        [HttpGet]
        public async Task<PagedResponse<TemplateStepDTO>> GetPagedListTemplateStep([FromQuery] GetPagedListTemplateStepQuery model)
        => await Mediator.Send(model);

        [HttpGet]
        public async Task<PagedResponse<TemplateStepDTO>> GetPagedListByActiveStatus([FromQuery] GetPagedListTemplateStepByActiveStatusQuery model)
        => await Mediator.Send(model);

        [HttpGet]
        public async Task<BaseResult<TemplateStepDTO>> GetTemplateStepById([FromQuery] GetTemplateStepByIdQuery model)
        => await Mediator.Send(model);

        [HttpPost, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Brand_Manager")]
        public async Task<BaseResult> CreateTemplateStep(CreateTemplateStepCommand model)
        => await Mediator.Send(model);

        [HttpPut, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Brand_Manager")]
        public async Task<BaseResult> UpdateTemplateStep(UpdateTemplateStepCommand model)
        => await Mediator.Send(model);

        [HttpDelete, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Brand_Manager")]
        public async Task<BaseResult> DeleteTemplateStep([FromQuery] DeleteTemplateStepCommand model)
        => await Mediator.Send(model);
    }
}
