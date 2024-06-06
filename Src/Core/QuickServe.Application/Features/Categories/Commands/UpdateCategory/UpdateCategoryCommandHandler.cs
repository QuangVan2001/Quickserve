﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QuickServe.Application.Helpers;
using QuickServe.Application.Interfaces;
using QuickServe.Application.Interfaces.Repositories;
using QuickServe.Application.Wrappers;

namespace QuickServe.Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, ITranslator translator) : IRequestHandler<UpdateCategoryCommand, BaseResult>
{
    public async Task<BaseResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.GetByIdAsync(request.Id);

        if (category is null)
        {
            return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.CategoryMessages.Category_not_Found_with_id(request.Id)), nameof(request.Id)));
        }
        if(await categoryRepository.ExistsCategoryByNameAsync(request.Name.Trim())) { 
            return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.CategoryMessages.Category_name_existed_with_name(request.Name)), nameof(request.Name)));
        }
        category.Update(request.Name.Trim());
        await unitOfWork.SaveChangesAsync();
        return new  BaseResult();
    }
}