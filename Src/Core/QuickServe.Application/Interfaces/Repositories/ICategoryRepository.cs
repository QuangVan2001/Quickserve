using System.Threading.Tasks;
using QuickServe.Application.DTOs;
using QuickServe.Domain.Categories.Dtos;
using QuickServe.Domain.Categories.Entities;

namespace QuickServe.Application.Interfaces.Repositories;

public interface ICategoryRepository  : IGenericRepository<Category>
{
    Task<PagenationResponseDto<CategoryDto>> GetPagedListAsync(int pageNumber, int pageSize, string name);
}