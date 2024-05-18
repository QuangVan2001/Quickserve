using MediatR;
using QuickServe.Application.Helpers;
using QuickServe.Application.Interfaces;
using QuickServe.Application.Interfaces.Repositories;
using QuickServe.Application.Wrappers;
using System.Threading;
using System.Threading.Tasks;

namespace QuickServe.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, ITranslator translator) : IRequestHandler<DeleteProductCommand, BaseResult>
    {
        public async Task<BaseResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.Id);

            if (product is null)
            {
                return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ProductMessages.Product_notfound_with_id(request.Id)), nameof(request.Id)));
            }

            productRepository.Delete(product);
            await unitOfWork.SaveChangesAsync();

            return new BaseResult();
        }
    }
}
