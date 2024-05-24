using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QuickServe.Application.Helpers;
using QuickServe.Application.Interfaces;
using QuickServe.Application.Interfaces.Repositories;
using QuickServe.Application.Wrappers;

namespace QuickServe.Application.Features.Store.Commands.UpdateStore;

public class UpdateStoreCommandHandler(IStoreRepository storeRepository, IUnitOfWork unitOfWork, ITranslator translator) : IRequestHandler<UpdateStoreCommand, BaseResult>
{
    public async Task<BaseResult> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
    {
        var store = await storeRepository.GetByIdAsync(request.Id);
        if (store is null)
        {
            return new BaseResult(new Error(ErrorCode.NotFound,
                translator.GetString(TranslatorMessages.StoreMessages.Store_notfound_with_id(request.Id)),
                nameof(request.Id)));
        }

        store.Update(request.Name, request.Address);
        await unitOfWork.SaveChangesAsync();
        return new BaseResult();
    }
}