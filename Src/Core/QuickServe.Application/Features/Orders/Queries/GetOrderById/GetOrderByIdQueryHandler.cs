using QuickServe.Application.Features.ProductTemplates.Queries.GetProductTemplateById;
using QuickServe.Application.Helpers;
using QuickServe.Application.Interfaces.Repositories;
using QuickServe.Application.Interfaces;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.ProductTemplates.Dtos;
using System.Threading.Tasks;
using System.Threading;
using MediatR;
using QuickServe.Application.Features.ProductTemplates.Queries.GetPagedListProductTemplate;
using QuickServe.Domain.Orders.Dtos;

namespace QuickServe.Application.Features.Orders.Queries.GetOrderById;

public class GetOrderByIdQueryHandler(IOrderRepository orderRepository) : IRequestHandler<GetOrderByIdQuery, BaseResult<OrderDto>>
{
    public async Task<BaseResult<OrderDto>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetByIdAsync(request.Id);
        if (order is null)
        {
            return new BaseResult<OrderDto>(new Error(ErrorCode.NotFound));
        }

        var result = new OrderDto(order);
        return new BaseResult<OrderDto>(result);
    }
}