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
        var ingredientType = await ingredientTypeRepository.GetByIdAsync(request.Id);

        if (ingredientType is null)
        {
            return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.IngredientTypeMessages.IngredientType_not_Found_with_id(request.Id)), nameof(request.Id)));
        }
        if (ingredientType.Ingredients.Count != 0)
        {
            return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.IngredientTypeMessages.IngredientType_exists_ingredient_with_id(request.Id)), nameof(request.Id)));
        }
        ingredientTypeRepository.Delete(ingredientType);
        await unitOfWork.SaveChangesAsync();
        return new BaseResult();
    }
}