using QuickServe.Application.DTOs;
using QuickServe.Domain.Products.Dtos;
using QuickServe.Domain.Products.Entities;
using System.Threading.Tasks;

namespace QuickServe.Application.Interfaces.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<PagenationResponseDto<ProductDto>> GetPagedListAsync(int pageNumber, int pageSize, string name);
    }
}
