using QuickServe.Application.DTOs;
using QuickServe.Domain.IngredientTypes.Dtos;
using QuickServe.Domain.IngredientTypes.Entities;
using System.Threading.Tasks;

namespace QuickServe.Application.Interfaces.Repositories;

public interface IIngredientTypeRepository : IGenericRepository<IngredientType>
{
    Task<PagenationResponseDto<IngredientTypeDTO>> GetPagedListAsync(int pageNumber, int pageSize, string name);
    Task<PagenationResponseDto<IngredientTypeDTO>> GetPagedListByAcitveStatusAsync(int pageNumber, int pageSize, string name);
    Task<bool> ExistByNameAsync(string name);
}