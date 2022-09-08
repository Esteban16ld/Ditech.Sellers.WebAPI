using System.Threading.Tasks;

namespace Ditech.Sellers.WebAPI.Data.Interfaces
{
    public interface IGenericRepository<in T>
    {
        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
