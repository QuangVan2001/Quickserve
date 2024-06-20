﻿using MediatR;
using QuickServe.Application.Features.ProductTemplates.Queries.GetPagedListProductTemplate;
using QuickServe.Application.Interfaces.Repositories;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Orders.Dtos;
using QuickServe.Domain.ProductTemplates.Dtos;
using System.Threading.Tasks;
using System.Threading;

namespace QuickServe.Application.Features.Orders.Queries.GetPagedListOrder;

public class GetPagedListOrderQueryHandler(IOrderRepository orderRepository) : IRequestHandler<GetPagedListOrderQuery, PagedResponse<OrderDto>>
{
    public async Task<PagedResponse<OrderDto>> Handle(GetPagedListOrderQuery request, CancellationToken cancellationToken)
    {
        var result = await orderRepository.GetOrderAsync(request.PageNumber, request.PageSize);

        return new PagedResponse<OrderDto>(result, request);
    }

}