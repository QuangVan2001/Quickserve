using MediatR;
using QuickServe.Application.DTOs.Orders.Response;
using QuickServe.Application.Helpers;
using QuickServe.Application.Interfaces.Repositories;
using QuickServe.Application.Interfaces;
using QuickServe.Application.Wrappers;
using System.Threading;
using System.Threading.Tasks;
using static QuickServe.Application.Helpers.TranslatorMessages;

namespace QuickServe.Application.Features.Orders.Commands.UpdateOrder;

public class UpdateOrderCommandHandler (ITranslator translator, IUnitOfWork unitOfWork, IOrderRepository orderRepository) : IRequestHandler<UpdateOrderCommand, BaseResult>
{
    public async Task<BaseResult> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        if (request.OrderId <= 0)
        {
            return new BaseResult<OrderResponse>(new Error(ErrorCode.FieldDataInvalid, "OrderId not valid"));
        }
        var order = await orderRepository.GetByIdAsync(request.OrderId);

        if (order is null)
        {
            return new BaseResult<OrderResponse>(new Error(ErrorCode.NotFound, "Order not found"));
        }
        
        if(order.Status != request.Status)
        {
            order.Status = request.Status;
            await unitOfWork.SaveChangesAsync();
        }

        return new BaseResult();
    }
}