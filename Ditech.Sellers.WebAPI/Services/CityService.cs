using Ditech.Sellers.WebAPI.Data.Interfaces;
using Ditech.Sellers.WebAPI.Data.Models.Dto;
using Ditech.Sellers.WebAPI.Models;
using Ditech.Sellers.WebAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ditech.Sellers.WebAPI.Services
{
    public class CityService :  ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<CityDto> Create(CityDto cityDto)
        {
            CityModel city = new CityModel()
            {
                DESCRIPTION = cityDto.DESCRIPTION
            };
            await _cityRepository.Add(city);
            return cityDto;
        }

        public async Task<bool> Delete(string description)
        {
            CityModel city = await _cityRepository.FindByDescription(description);

            if (city is null)
                throw new System.Exception("Ciudad no registrada");

            await _cityRepository.DeleteByDescription(city.DESCRIPTION);
            return true;
        }

        public async Task<ICollection<CityModel>> FindAll()
        {
            return await _cityRepository.FindAll();
        }
    }
}
