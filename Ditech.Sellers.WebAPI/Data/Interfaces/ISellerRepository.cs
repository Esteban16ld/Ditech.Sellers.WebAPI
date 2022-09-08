using Ditech.Sellers.WebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ditech.Sellers.WebAPI.Data.Interfaces
{
    public interface ISellerRepository : IGenericRepository<SellerModel>
    {
        Task<SellerModel> FindByDocument(string document);
        Task<ICollection<SellerModel>> FindByCity(int cityId);
        Task DeleteByDocument(string document);
        Task<ICollection<SellerModel>> FindAll();
    }
}
