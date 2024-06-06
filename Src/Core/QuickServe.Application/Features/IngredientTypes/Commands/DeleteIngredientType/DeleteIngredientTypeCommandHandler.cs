using MediatR;
using QuickServe.Application.Helpers;
using QuickServe.Application.Interfaces.Repositories;
using QuickServe.Application.Interfaces;
using QuickServe.Application.Wrappers;
using System.Threading.Tasks;
using System.Threading;

namespace QuickServe.Application.Features.IngredientTypes.Commands.DeleteIngredientType;

public class DeleteIngredientTypeCommandHandler(IIngredientTypeRepository ingredientTypeRepository, IUnitOfWork unitOfWork, ITranslator translator) : IRequestHandler<DeleteIngredientTypeCommand, BaseResult>
{
    public async Task<BaseResult> Handle(DeleteIngredientTypeCommand request, CancellationToken cancellationToken)
    {
        var ingredientType = await ingredientTypeRepository.GetIngredientTypeByIdAsync(request.Id);

        if (ingredientType is null)
        {
            return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.IngredientTypeMessages.Loại_nguyên_liệu_không_tìm_thấy_với_id(request.Id)), nameof(request.Id)));
        }
        if (ingredientType.Ingredients.Count != 0)
        {
            return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.IngredientTypeMessages.Loại_nguyên_liệu_tồn_tại_nguyên_liệu_với_id(request.Id)), nameof(request.Id)));
        }
        ingredientTypeRepository.Delete(ingredientType);
        await unitOfWork.SaveChangesAsync();
        return new BaseResult();
    }
}