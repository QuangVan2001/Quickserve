using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QuickServe.Application.Helpers;
using QuickServe.Application.Interfaces;
using QuickServe.Application.Interfaces.Repositories;
using QuickServe.Application.Wrappers;

namespace QuickServe.Application.Features.Store.Commands.DeleteStore;

public class DeleteStoreCommandHandler(IStoreRepository storeRepository, IUnitOfWork unitOfWork, ITranslator translator) : IRequestHandler<DeleteStoreCommand, BaseResult>
{
    public async Task<BaseResult> Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
    {
        var store = await storeRepository.GetByIdAsync(request.Id);
        if (store is null)
        {
            return new BaseResult(new Error(ErrorCode.NotFound,
                translator.GetString(TranslatorMessages.StoreMessages.Cửa_hàng_không_tìm_thấy_với_id(request.Id)),
                nameof(request.Id)));
        }
        storeRepository.Delete(store);
        await unitOfWork.SaveChangesAsync();
        return new BaseResult();
    }
}