﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuickServe.Application.DTOs.Nutritions.Request;
using QuickServe.Application.DTOs.Orders.Response;
using QuickServe.Application.Features.Orders.Commands.CreateOrder;
using QuickServe.Application.Features.Orders.Commands.UpdateOrder;
using QuickServe.Application.Features.Orders.Queries.GetOrderById;
using QuickServe.Application.Features.Orders.Queries.GetPagedListOrder;
using QuickServe.Application.Features.ProductTemplates.Queries.GetPagedListProductTemplate;
using QuickServe.Application.Features.ProductTemplates.Queries.GetProductTemplateById;
using QuickServe.Application.Features.Store.Commands.CreateStore;
using QuickServe.Application.Interfaces.IOrderServices;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Orders.Dtos;
using QuickServe.Domain.ProductTemplates.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuickServe.WebApi.Controllers.v1
{
    [ApiVersion("1")]
    public class OrdersController : BaseApiController
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet()]
        public async Task<PagedResponse<OrderDto>> GetOrderById([FromQuery] GetPagedListOrderQuery command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("{id}")]
        public async Task<BaseResult<OrderDto>> GetOrderById(long id)
        {
            return await Mediator.Send(new GetOrderByIdQuery { Id = id });
        }

        [HttpPost("CreateOrder")]
        public async Task<BaseResult<OrderResponse>> CreateOrder(CreateOrderCommand command)
        {
            return await _orderService.CreateOrderAsync(command);
        }

        [HttpPut("UpdateOrderStatus")]
        public async Task<BaseResult> UpdateOrderStatus(UpdateOrderCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}