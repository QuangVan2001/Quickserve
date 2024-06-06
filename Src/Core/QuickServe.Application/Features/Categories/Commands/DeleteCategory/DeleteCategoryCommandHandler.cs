using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QuickServe.Application.Helpers;
using QuickServe.Application.Interfaces;
using QuickServe.Application.Interfaces.Repositories;
using QuickServe.Application.Wrappers;

namespace QuickServe.Application.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, ITranslator translator) : IRequestHandler<DeleteCategoryCommand, BaseResult>
{
    public async Task<BaseResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.FindByIdAsync(request.Id);

        if (category is null)
        {
            return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.CategoryMessages.Danh_mục_không_tìm_thấy_với_id(request.Id)), nameof(request.Id)));
        }
        if(category.ProductTemplates.Count != 0)
        {
            return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.CategoryMessages.Danh_mục_tồn_tại_mẫu_sản_phẩm_với_id(request.Id)), nameof(request.Id)));
        }
        categoryRepository.Delete(category);
        await unitOfWork.SaveChangesAsync();

        return new BaseResult();
    }
}