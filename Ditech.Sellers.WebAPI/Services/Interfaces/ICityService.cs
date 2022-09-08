using Ditech.Sellers.WebAPI.Data.Models.Dto;
using Ditech.Sellers.WebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ditech.Sellers.WebAPI.Services.Interfaces
{
    public interface ICityService
    {
        Task<CityDto> Create(CityDto cityDto);
        Task<bool> Delete(string document);
        Task<ICollection<CityModel>> FindAll();
    }
}
