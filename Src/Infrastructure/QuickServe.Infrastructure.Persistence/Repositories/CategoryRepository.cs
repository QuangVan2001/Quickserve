using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuickServe.Application.DTOs;
using QuickServe.Application.Interfaces.Repositories;
using QuickServe.Domain.Categories.Dtos;
using QuickServe.Domain.Categories.Entities;
using QuickServe.Infrastructure.Persistence.Contexts;

namespace QuickServe.Infrastructure.Persistence.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    private readonly DbSet<Category> categories;
    
    public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        categories = dbContext.Set<Category>();
    }

    public async Task<PagenationResponseDto<CategoryDto>> GetPagedListAsync(int pageNumber, int pageSize, string name)
    {
        var query = categories.OrderBy(c => c.Created).AsQueryable();
        if (!string.IsNullOrEmpty(name))
        {
            query = query.Where(c => c.Name.Contains(name));
        }

      
        return await Paged(
            query.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Created = c.Created,
                CreatedBy = c.CreatedBy,
                LastModified = c.LastModified ?? null,  // Xử lý giá trị NULL
                LastModifiedBy = c.LastModifiedBy ?? null // Xử lý giá trị NULL
            }),
            pageNumber,
            pageSize);
    }
    
}