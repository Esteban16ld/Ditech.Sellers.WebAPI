using Ditech.Sellers.WebAPI.Data.Interfaces;
using Ditech.Sellers.WebAPI.Models;
using Ditech.Sellers.WebAPI.Models.Dto;
using Ditech.Sellers.WebAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Ditech.Sellers.WebAPI.Services
{
    public class SellerService : ISellerService
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly ICityRepository _cityRepository;

        public SellerService(ISellerRepository sellerRepository, ICityRepository cityRepository)
        {
            _sellerRepository = sellerRepository;
            _cityRepository = cityRepository;
        }

        public async Task<bool> Create(SellerDto sellerDto)
        {
            CityModel city = await _cityRepository.FindByDescription(sellerDto.CITY_NAME);
            SellerModel seller = await _sellerRepository.FindByDocument(sellerDto.DOCUMENT);

            if (city is null || seller != null)
                throw new System.Exception("Sucursal no registrada o vendedor ya existe");
           
            SellerModel newSeller = new SellerModel {
                NAME = sellerDto.NAME,
                LAST_NAME = sellerDto.LAST_NAME,
                DOCUMENT = sellerDto.DOCUMENT,
                CITY_ID = city.CODE
            };

            await _sellerRepository.Add(newSeller);
            return true;
        }

        public async Task<ICollection<SellerDto>> FindByCity(string cityDescription)
        {
            CityModel city = await _cityRepository.FindByDescription(cityDescription);
            ICollection<SellerModel> sellers = await _sellerRepository.FindByCity(city.CODE);

            if (city is null || sellers is null)
                throw new System.Exception("Ciudad o vendedor no registrada");
            
            return sellers.Select(s => new SellerDto
            {
                CODE = s.CODE,
                NAME = s.NAME,
                DOCUMENT = s.DOCUMENT,
                LAST_NAME = s.LAST_NAME,
                CITY_NAME = city.DESCRIPTION
            }).ToList();
        }

        public async Task<SellerDto> Update(SellerDto sellerDto)
        {
            CityModel city = await _cityRepository.FindByDescription(sellerDto.CITY_NAME);
            SellerModel seller = await _sellerRepository.FindByDocument(sellerDto.DOCUMENT);

            if (city is null || seller is null)
                throw new System.Exception("Ciudad o vendedor no registrada");

            seller.NAME = sellerDto.NAME;
            seller.LAST_NAME = sellerDto.LAST_NAME;
            seller.CITY_ID = city.CODE;

            _sellerRepository.Update(seller);
            return sellerDto;
        }

        public async Task<bool> Delete(string document)
        {
            SellerModel seller = await _sellerRepository.FindByDocument(document);

            if (seller is null)
                throw new System.Exception("Vendedor no registrado");

            await _sellerRepository.DeleteByDocument(seller.DOCUMENT);
            return true;
        }

        public async Task<List<SellerDto>> FindAll()
        {
            ICollection<SellerModel> sellers = await _sellerRepository.FindAll();
            List<SellerDto> sellersDto = new List<SellerDto>();

            if (sellers is null)
                throw new System.Exception("Vendedores no registrados");

            foreach (SellerModel seller in sellers)
            {
                CityModel city = await _cityRepository.FindByCode(seller.CITY_ID);

                SellerDto sellerDto = new SellerDto
                {
                    CODE = seller.CODE,
                    NAME = seller.NAME,
                    DOCUMENT = seller.DOCUMENT,
                    LAST_NAME = seller.LAST_NAME,
                    CITY_NAME = city.DESCRIPTION
                };

                sellersDto.Add(sellerDto);
            }
            return sellersDto;
        }
    }
}
