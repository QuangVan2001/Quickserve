using MediatR;
using QuickServe.Application.Features.Categories.Commands.UpdateCategory;
using QuickServe.Application.Helpers;
using QuickServe.Application.Interfaces.Repositories;
using QuickServe.Application.Interfaces;
using QuickServe.Application.Wrappers;
using System.Threading.Tasks;
using System.Threading;

namespace QuickServe.Application.Features.Ingredients.Commands.UpdateIngredient;

public class UpdateIngredientCommandHandler(IIngredientRepository ingredientRepositiry, IUnitOfWork unitOfWork, ITranslator translator) : IRequestHandler<UpdateIngredientCommand, BaseResult>
{
    public async Task<BaseResult> Handle(UpdateIngredientCommand request, CancellationToken cancellationToken)
    {
        var ingredient = await ingredientRepositiry.GetByIdAsync(request.Id);

        if (ingredient is null)
        {
            return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.IngredientMessages.Nguyên_liệu_không_tìm_thấy_với_id(request.Id)), nameof(request.Id)));
        }
        if (await ingredientRepositiry.ExistByNameAsync(request.Name.Trim()))
        {
            return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.IngredientMessages.Tên_nguyên_liệu_đã_tồn_tại_với_tên(request.Name)), nameof(request.Name)));
        }
        ingredient.Update(request.Name.Trim(), request.Price, request.Calo, request.Description
            ,request.IngredientTypeId);
        await unitOfWork.SaveChangesAsync();
        return new BaseResult();
    }
}