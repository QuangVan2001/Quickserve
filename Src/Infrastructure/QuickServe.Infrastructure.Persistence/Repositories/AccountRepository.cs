using Microsoft.EntityFrameworkCore;
using QuickServe.Application.Interfaces.Repositories;
using QuickServe.Domain.Accounts.Dtos;
using QuickServe.Domain.Accounts.Entities;
using QuickServe.Domain.Categories.Entities;
using QuickServe.Infrastructure.Persistence.Contexts;
using System;
using System.Threading.Tasks;

namespace QuickServe.Infrastructure.Persistence.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        private readonly DbSet<Account> accounts;
        public AccountRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            accounts = dbContext.Set<Account>();
        }

        public async Task<Account> FindByIdAsync(Guid id)
        {
            return await accounts.Include(c=>c.Staff)
                .ThenInclude(c=>c.Store)
            .FirstOrDefaultAsync(c=> c.Id == id);
        }
    }
}
