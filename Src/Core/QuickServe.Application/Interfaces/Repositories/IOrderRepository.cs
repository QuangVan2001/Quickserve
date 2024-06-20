using QuickServe.Application.DTOs;
using QuickServe.Domain.Categories.Entities;
using QuickServe.Domain.Orders.Dtos;
using QuickServe.Domain.Orders.Entities;
using System.Threading.Tasks;

namespace QuickServe.Application.Interfaces.Repositories;

public interface IOrderRepository : IGenericRepository<Order>
{
    Task<Order> GetByIdAsync(long id);

    Task<PagenationResponseDto<OrderDto>> GetOrderAsync(int pageNumber, int pageSize);
}