﻿using MediatR;
using QuickServe.Application.Features.Categories.Commands.UpdateCategory;
using QuickServe.Application.Helpers;
using QuickServe.Application.Interfaces.Repositories;
using QuickServe.Application.Interfaces;
using QuickServe.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuickServe.Application.Features.TemplateSteps.Commands.UpdateTemplateStep
{
    public class UpdateTemplateStepCommandHandler(ITemplateStepRepository templateStepRepository, IUnitOfWork unitOfWork, ITranslator translator) : IRequestHandler<UpdateTemplateStepCommand, BaseResult>
    {
        public async Task<BaseResult> Handle(UpdateTemplateStepCommand request, CancellationToken cancellationToken)
        {
            var templateStep = await templateStepRepository.GetByIdAsync(request.Id);

            if (templateStep is null)
            {
                return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.TemplateStepMessages.Bước_mẫu_không_tìm_thấy_với_id(request.Id)), nameof(request.Id)));
            }
            if (await templateStepRepository.ExistNameAsync(templateStep.ProductTemplateId, request.Name.Trim()))
            {
                return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.TemplateStepMessages.Tên_bước_mẫu_đã_tồn_tại(request.Name)), nameof(request.Name)));
            }
            templateStep.Update(request.Name.Trim());
            await unitOfWork.SaveChangesAsync();
            return new BaseResult();
        }
    }
}
