using Ditech.Sellers.WebAPI.Data.Interfaces;
using System.Threading.Tasks;

namespace Ditech.Sellers.WebAPI.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
