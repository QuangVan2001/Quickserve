using System.Threading.Tasks;
using QuickServe.Application.DTOs;
using QuickServe.Domain.Categories.Dtos;
using QuickServe.Domain.Categories.Entities;

namespace QuickServe.Application.Interfaces.Repositories;

public interface ICategoryRepository  : IGenericRepository<Category>
{
    Task<Category> FindByIdAsync(long id);
    Task<PagenationResponseDto<CategoryDto>> GetPagedListAsync(int pageNumber, int pageSize, string name);
    Task<PagenationResponseDto<CategoryDto>> GetPagedListByAcitveStatusAsync(int pageNumber, int pageSize, string name);
    Task<bool> ExistsCategoryByNameAsync(string name);
}