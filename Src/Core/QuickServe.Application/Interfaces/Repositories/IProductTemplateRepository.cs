using System.Threading.Tasks;
using QuickServe.Application.DTOs;
using QuickServe.Domain.ProductTemplates.Dtos;
using QuickServe.Domain.ProductTemplates.Entities;

namespace QuickServe.Application.Interfaces.Repositories;

public interface IProductTemplateRepository : IGenericRepository<ProductTemplate>
{
    Task<PagenationResponseDto<ProductTemplateDto>> GetPagedListAsync(int pageNumber, int pageSize, string name);

}