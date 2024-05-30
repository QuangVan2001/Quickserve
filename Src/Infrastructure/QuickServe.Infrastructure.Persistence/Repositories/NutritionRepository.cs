using Microsoft.EntityFrameworkCore;
using QuickServe.Application.Interfaces.Repositories;
using QuickServe.Domain.Ingredients.Entities;
using QuickServe.Domain.Nutritions.Entities;
using QuickServe.Infrastructure.Persistence.Contexts;

namespace QuickServe.Infrastructure.Persistence.Repositories;

public class NutritionRepository : GenericRepository<Nutrition>, INutritionRepository
{
    private readonly DbSet<Nutrition> nutritions;

    public NutritionRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        nutritions = dbContext.Set<Nutrition>();
    }
}