using AutoMapper;
using Ditech.Sellers.WebAPI.Models;
using Ditech.Sellers.WebAPI.Models.Dto;

namespace Ditech.Sellers.WebAPI.Mapping
{
    public class SellerProfile : Profile
    {
        public SellerProfile()
        {
            CreateMap<SellerDto, SellerModel>();
        }
    }
}
