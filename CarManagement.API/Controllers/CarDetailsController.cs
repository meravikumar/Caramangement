using CarManagement.Business.IServices;
using CarManagement.Business.Service;
using CarManagement.Core.Constants;
using CarManagement.Core.ViewModels.CarDetails;
using CarManagement.Core.ViewModels.Cars;
using CarManagement.Core.ViewModels.Companies;
using CarManagement.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CarManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardetailsController : ControllerBase
    {
        public readonly ICarDetailService _carDetailService;
        public CardetailsController(ICarDetailService carDetailService)
        {
            _carDetailService = carDetailService;
        }


        [HttpGet]
        public async Task<ActionResult<List<CarDetails>>> GetAllCarAsync()
        {
            return Ok(await _carDetailService.GetAllCarDetailAsync());
        }


        [HttpGet("{CarDetailId}")]
        public async Task<IActionResult>GetCarDetailById(int CarDetailId)
        {
            return Ok(await _carDetailService.GetCarDetailByIdAsync(CarDetailId));
        }


        [HttpPost]
        public async Task<IActionResult> AddCarDetails([FromBody] CreateCarDetailVM createCarDetailVM)
        {
            var createCarDetail= await _carDetailService.CreateCarDetailAsync(createCarDetailVM);
            if(createCarDetail==null)
            {
                return BadRequest("Some field or may be CarId is not matched");
            }
            return Ok(new { CarCreate = StringConstants.CreateSuccess });

        }


        [HttpPut("{carDetailId}")]
        public async Task<IActionResult> UpdateCarDetail(int carDetailId, [FromBody] EditCarDetailVM editCarDetailVM)
        {
            var updatedCar = await _carDetailService.UpdateCarDetailAsync(carDetailId, editCarDetailVM);
            if (updatedCar == null)
                return NotFound();
            return Ok(new { message = StringConstants.UpdateSuccess });
        }


        [HttpDelete("{carDetailId}")]
        public async Task<IActionResult> DeleteCardetail(int carDetailId)
        {
            var result = _carDetailService.DeleteCarDetailAsync(carDetailId);
            if(result == null)
            {
                return NotFound("Detail is not available in database");
            }
            return Ok(new { message = StringConstants.DeleteSuccess});
        }

    }
}
