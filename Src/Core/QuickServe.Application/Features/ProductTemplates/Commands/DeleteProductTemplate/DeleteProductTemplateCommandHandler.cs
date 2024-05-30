using MediatR;
using QuickServe.Application.Features.IngredientTypes.Commands.DeleteIngredientType;
using QuickServe.Application.Helpers;
using QuickServe.Application.Interfaces.Repositories;
using QuickServe.Application.Interfaces;
using QuickServe.Application.Wrappers;
using System.Threading.Tasks;
using System.Threading;

namespace QuickServe.Application.Features.ProductTemplates.Commands.DeleteProductTemplate;

public class DeleteProductTemplateCommandHandler(IProductTemplateRepository productTemplateRepository, IUnitOfWork unitOfWork, ITranslator translator) : IRequestHandler<DeleteProductTemplateCommand, BaseResult>
{
    public async Task<BaseResult> Handle(DeleteProductTemplateCommand request, CancellationToken cancellationToken)
    {
        var ingredientType = await productTemplateRepository.GetProductTemplateByIdAsync(request.Id);

        if (ingredientType is null)
        {
            return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ProductTemplateMessages.ProductTemplate_not_found_with_id(request.Id)), nameof(request.Id)));
        }
        if (ingredientType.Products.Count != 0 || ingredientType.TemplateSteps.Count != 0)
        {
            return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ProductTemplateMessages.ProductTemplate_exists_products_and_templatesteps(request.Id)), nameof(request.Id)));
        }
        productTemplateRepository.Delete(ingredientType);
        await unitOfWork.SaveChangesAsync();
        return new BaseResult();
    }
}