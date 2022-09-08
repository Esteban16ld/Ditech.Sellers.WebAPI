using AutoMapper;
using Ditech.Sellers.WebAPI.Data.Models.Dto;
using Ditech.Sellers.WebAPI.Models;

namespace Ditech.Sellers.WebAPI.Mapper
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<CityDto, CityModel>();
        }
    }
}
