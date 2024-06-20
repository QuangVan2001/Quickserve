using Microsoft.EntityFrameworkCore;
using QuickServe.Application.DTOs;
using QuickServe.Application.Interfaces.Repositories;
using QuickServe.Domain.Categories.Entities;
using QuickServe.Domain.Orders.Dtos;
using QuickServe.Domain.Orders.Entities;
using QuickServe.Domain.ProductTemplates.Entities;
using QuickServe.Domain.Stores.Entities;
using QuickServe.Infrastructure.Persistence.Contexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickServe.Infrastructure.Persistence.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    private readonly DbSet<Order> orders;

    public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        orders = dbContext.Set<Order>();
    }

    public async Task<Order> GetByIdAsync(long id)
    {
        return await orders.FirstOrDefaultAsync(o => o.Id == id);
    }
    public async Task<PagenationResponseDto<OrderDto>> GetOrderAsync(int pageNumber, int pageSize)
    {
        var query = orders.AsNoTracking();
        return await Paged(
            query.Select(s => new OrderDto(s)),
            pageNumber,
            pageSize);
    }
}