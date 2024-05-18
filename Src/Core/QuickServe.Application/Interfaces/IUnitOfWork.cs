using System.Threading.Tasks;

namespace QuickServe.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync();
    }
}
