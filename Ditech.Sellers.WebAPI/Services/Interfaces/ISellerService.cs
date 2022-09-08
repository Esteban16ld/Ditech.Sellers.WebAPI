using Ditech.Sellers.WebAPI.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ditech.Sellers.WebAPI.Services.Interfaces
{
    public interface ISellerService
    {
        Task<bool> Create(SellerDto sellerDto);
        Task<ICollection<SellerDto>> FindByCity(string cityDescription);
        Task<SellerDto> Update(SellerDto sellerDto);
        Task<bool> Delete(string document);
        Task<List<SellerDto>> FindAll();
    }
}
