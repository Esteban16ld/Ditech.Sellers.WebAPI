using Ditech.Sellers.WebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ditech.Sellers.WebAPI.Data.Interfaces
{
    public interface ICityRepository : IGenericRepository<CityModel>
    {
        Task<CityModel> FindByDescription(string description);
        Task<CityModel> FindByCode(int code);
        Task DeleteByDescription(string description);
        Task<ICollection<CityModel>> FindAll();
    }
}
