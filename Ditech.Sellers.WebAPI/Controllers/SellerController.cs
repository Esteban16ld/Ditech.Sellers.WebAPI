using Ditech.Sellers.WebAPI.Data.Interfaces;
using Ditech.Sellers.WebAPI.Models.Dto;
using Ditech.Sellers.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Ditech.Sellers.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly ISellerService _sellerService;
        private readonly IUnitOfWork _unitOfWork;

        public SellerController(ISellerService sellerService, IUnitOfWork unitOfWork)
        {
            _sellerService = sellerService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("CreateSeller")]
        public async Task<IActionResult> CreateSeller(SellerDto sellerDto)
        {
            try
            {
                await _sellerService.Create(sellerDto);
                await _unitOfWork.SaveChangesAsync();
                return Ok(sellerDto);
            }
            catch (System.Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("FindByCity")]
        public async Task<IActionResult> FindByCity(string cityDescription)
        {
            try
            {
                ICollection<SellerDto> sellers = await _sellerService.FindByCity(cityDescription);
                return Ok(sellers);
            }
            catch (System.Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateSeller")]
        public async Task<IActionResult> UpdateSeller(SellerDto sellerDto)
        {
            try
            {
                await _sellerService.Update(sellerDto);
                await _unitOfWork.SaveChangesAsync();
                return Ok(sellerDto);
            }
            catch (System.Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteSeller")]
        public async Task<IActionResult> DeleteSeller(string document)
        {
            try
            {
                await _sellerService.Delete(document);
                await _unitOfWork.SaveChangesAsync();
                return Ok(true);
            }
            catch (System.Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetSellers")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                return Ok(await _sellerService.FindAll());
            }
            catch (System.Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
