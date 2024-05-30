using MediatR;
using QuickServe.Application.Features.Categories.Commands.UpdateCategory;
using QuickServe.Application.Helpers;
using QuickServe.Application.Interfaces.Repositories;
using QuickServe.Application.Interfaces;
using QuickServe.Application.Wrappers;
using System.Threading.Tasks;
using System.Threading;

namespace QuickServe.Application.Features.IngredientTypes.Commands.UpdateIngredientType;

public class UpdateIngredientTypeCommandHandler(IIngredientTypeRepository ingredientTypeRepository, IUnitOfWork unitOfWork, ITranslator translator) : IRequestHandler<UpdateIngredientTypeCommand, BaseResult>
{
    public async Task<BaseResult> Handle(UpdateIngredientTypeCommand request, CancellationToken cancellationToken)
    {
        var ingredientType = await ingredientTypeRepository.GetByIdAsync(request.Id);

        if (ingredientType is null)
        {
            return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.IngredientTypeMessages.IngredientType_not_Found_with_id(request.Id)), nameof(request.Id)));
        }
        if (await ingredientTypeRepository.ExistByNameAsync(request.Name.Trim()))
        {
            return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.CategoryMessages.Category_name_existed_with_name(request.Name)), nameof(request.Name)));
        }
        ingredientType.Update(request.Name.Trim());
        await unitOfWork.SaveChangesAsync();
        return new BaseResult();
    }
}