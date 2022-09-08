using Ditech.Sellers.WebAPI.Data.Interfaces;
using System.Threading.Tasks;

namespace Ditech.Sellers.WebAPI.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public DataContext _context { get; private set; }

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
