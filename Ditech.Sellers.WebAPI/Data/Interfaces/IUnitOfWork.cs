using System.Threading.Tasks;

namespace Ditech.Sellers.WebAPI.Data.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
