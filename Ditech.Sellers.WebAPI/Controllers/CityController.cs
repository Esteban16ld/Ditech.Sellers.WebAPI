using AutoMapper;
using Ditech.Sellers.WebAPI.Data.Interfaces;
using Ditech.Sellers.WebAPI.Data.Models.Dto;
using Ditech.Sellers.WebAPI.Models;
using Ditech.Sellers.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Ditech.Sellers.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        private readonly IUnitOfWork _unitOfWork;

        public CityController(ICityService cityService, IUnitOfWork unitOfWork)
        {
            _cityService = cityService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("CreateCity")]
        public async Task<IActionResult> CreateCity(CityDto cityDto)
        {
            try
            {
                await _cityService.Create(cityDto);
                await _unitOfWork.SaveChangesAsync();
                return Ok(cityDto);
            }
            catch (System.Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteCity")]
        public async Task<IActionResult> DeleteCity(string description)
        {
            try
            {
                await _cityService.Delete(description);
                await _unitOfWork.SaveChangesAsync();
                return Ok(true);
            }
            catch (System.Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetCities")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                return Ok(await _cityService.FindAll());
            }
            catch (System.Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
