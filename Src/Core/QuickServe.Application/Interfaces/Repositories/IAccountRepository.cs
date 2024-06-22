using QuickServe.Domain.Accounts.Entities;
using System;
using System.Threading.Tasks;

namespace QuickServe.Application.Interfaces.Repositories
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Task<Account> FindByIdAsync(Guid id);
    }
}
