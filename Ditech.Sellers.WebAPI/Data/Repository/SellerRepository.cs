using Ditech.Sellers.WebAPI.Data.Interfaces;
using Ditech.Sellers.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ditech.Sellers.WebAPI.Data.Repository
{
    public class SellerRepository : GenericRepository<SellerModel>, ISellerRepository
    {
        private readonly DataContext _context;

        public SellerRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<SellerModel> FindByDocument(string document)
        {
            SellerModel seller = await _context.Seller
                .Where(s => s.DOCUMENT.Equals(document))
                .SingleOrDefaultAsync();
            return seller;
        }

        public async Task<ICollection<SellerModel>> FindByCity(int cityId)
        {
            ICollection<SellerModel> sellers = await _context.Seller
                .Where(s => s.CITY_ID.Equals(cityId))
                .ToListAsync();
            return sellers;
        }

        public async Task DeleteByDocument(string document)
        {
            SellerModel seller = await _context.Seller
                .Where(s => s.DOCUMENT.Equals(document))
                .SingleOrDefaultAsync();
            if(seller != null)
                _context.Seller.Remove(seller);
        }

        public async Task<ICollection<SellerModel>> FindAll()
        {
            ICollection<SellerModel> sellers = await _context.Seller
                .ToListAsync();
            return sellers;
        }
    }
}
