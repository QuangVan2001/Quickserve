using MediatR;
using QuickServe.Application.Features.Categories.Commands.CreateCategory;
using QuickServe.Application.Helpers;
using QuickServe.Application.Interfaces.Repositories;
using QuickServe.Application.Interfaces;
using QuickServe.Application.Utils.Enums;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Categories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using QuickServe.Domain.TemplateSteps.Entities;

namespace QuickServe.Application.Features.TemplateSteps.Commands.CreateTemplateStep
{
    public class CreateTemplateStepCommandHandler(ITemplateStepRepository templateStepRepository, IUnitOfWork unitOfWork, ITranslator translator) : IRequestHandler<CreateTemplateStepCommand, BaseResult>
    {
        public async Task<BaseResult> Handle(CreateTemplateStepCommand request, CancellationToken cancellationToken)
        {
            if (await templateStepRepository.ExistNameAsync(request.ProductTemplateId,request.Name.Trim()))
            {
                return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.TemplateStepMessages.TemplateStep_existed_with_name(request.Name)), nameof(request.Name)));
            }
            var templateStep = new TemplateStep(request.Name.Trim());
            templateStep.Status = (int)CategoryStatus.Inactive;
            templateStep.ProductTemplateId = request.ProductTemplateId;
            await templateStepRepository.AddAsync(templateStep);
            await unitOfWork.SaveChangesAsync();
            return new BaseResult<long>(templateStep.Id);
        }
    }
}