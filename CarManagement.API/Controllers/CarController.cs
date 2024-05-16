using CarManagement.Business.IServices;
using CarManagement.Business.Service;
using CarManagement.Core.Constants;
using CarManagement.Core.ViewModels.Cars;
using CarManagement.Core.ViewModels.Companies;
using CarManagement.Data.IRepository;
using CarManagement.Data.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CarManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;
        }
        [HttpGet]
        public async Task<ActionResult<List<CreateCompanyVM>>>GetAllCarAsync()
        {
            return Ok(await _carService.GetAllCarsAsync());
        }


        [HttpGet("{carId}")]
        public async Task<IActionResult> GetCarById(int carId)
        {
            return Ok(await _carService.GetCarByIdAsync(carId));
        }


        [HttpPost]
        public async Task<IActionResult> CreateNewCar([FromBody] CreateCarVM createCarVM)
        {
            var createdcar = await _carService.CreateCarAsync(createCarVM);
            if (createdcar == null)
            {
                return BadRequest("Some field or may be company id is not matched");
            }
            //return CreatedAtAction(nameof(GetCompany), new { companyId = createdCompany.CompanyId }, createdCompany);
            return Ok(new { CarCreate = StringConstants.CreateSuccess });
        }


        [HttpPut("{carId}")]
        public async Task<IActionResult> UpdateCar(int carId, [FromBody] CreateCarVM carVM)
        {
            var updatedCar = await _carService.UpdateCarAsync(carId, carVM);
            if (updatedCar == null)
                return NotFound();
            return Ok(new { message = StringConstants.UpdateSuccess });
        }


        [HttpDelete("{carId}")]
        public async Task<IActionResult> DeleteCar(int carId)
        {
            var result = await _carService.DeleteCarAsync(carId);
            if (!result)
            {
                return NotFound();
            }

            return Ok(new { message = StringConstants.DeleteSuccess });
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> EditCompanyPatch(int id, [FromBody] JsonPatchDocument<Car> carPatch)
        {
            var success = await _carService.UpdateCarWithPatchAsync(id, carPatch);
            if (!success)
            {
                return NotFound();
            }

            return Ok(new { message = StringConstants.CreateSuccess });
        }



    }
}
