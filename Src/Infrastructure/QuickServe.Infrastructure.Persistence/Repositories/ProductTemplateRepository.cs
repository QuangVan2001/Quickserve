using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuickServe.Application.DTOs;
using QuickServe.Application.Interfaces.Repositories;
using QuickServe.Domain.ProductTemplates.Dtos;
using QuickServe.Domain.ProductTemplates.Entities;
using QuickServe.Infrastructure.Persistence.Contexts;

namespace QuickServe.Infrastructure.Persistence.Repositories;

public class ProductTemplateRepository : GenericRepository<ProductTemplate>,IProductTemplateRepository
{
    private readonly DbSet<ProductTemplate> _productTemplates;
    public ProductTemplateRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _productTemplates = dbContext.Set<ProductTemplate>();
    }

    public async Task<PagenationResponseDto<ProductTemplateDto>> GetPagedListAsync(int pageNumber, int pageSize, string name)
    {
        var query = _productTemplates.OrderBy(p => p.Created).AsQueryable();
        if (!string.IsNullOrEmpty(name))
        {
            query = query.Where(s => s.Name.Contains(name));
        }

        return null;
    }
}