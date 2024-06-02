using Microsoft.EntityFrameworkCore;
using QuickServe.Domain.Accounts.Entities;
using QuickServe.Infrastructure.Persistence.Contexts;

namespace QuickServe.Infrastructure.Persistence.Repositories
{
    public class AccountRepository : GenericRepository<Account>
    {
        public AccountRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
