using AutoMapper;
using CarManagement.Business.IServices;
using CarManagement.Core.Constants;
using CarManagement.Core.ViewModels.Companies;
using CarManagement.Core.ViewModels.LoginToken;
using CarManagement.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CarManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    /*[Authorize]*/
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<CreateCompanyVM>>> GetAll()
        {
            var entities = await _companyService.GetAllAsync();
            //List<CreateCompanyVM> result = _mapper.Map<List<CreateCompanyVM>>(entities);
            List<CreateCompanyVM> companies = new List<CreateCompanyVM>();
            foreach (var entity in entities)
            {
                CreateCompanyVM obj = new CreateCompanyVM()
                {
                    CompanyId =entity.CompanyId,
                    CompanyName = entity.CompanyName,
                    EstablishedDate = entity.EstablishedDate != null ?
                    new DateTime(entity.EstablishedDate.Year, entity.EstablishedDate.Month, entity.EstablishedDate.Day) :
                         (DateTime?)null,
                    IsFinanceProvider = entity.IsFinanceProvider,
                    Location = entity.Location,
                    CEO = entity.CEO
                };
                companies.Add(obj);
            }
            return Ok(companies);
        }


		[HttpGet]
		[Route("GetCompany")]
		public async Task<IActionResult> GetCompany([FromQuery]int companyId)
		{
			var companyVM = await _companyService.GetCompanyAsyncByID(companyId);
			if (companyVM == null)
				return NotFound();
			return Ok(companyVM);
		}


		[HttpPost]
        [Route("AddCompany")]
        public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyVM companyVM)
        {
            var createdCompany = await _companyService.CreateCompanyAsync(companyVM);
            /*var apiResponse = new APIResponseVM<object>()
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = StringConstants.CreateSuccess,
            };*/
            //return CreatedAtAction(nameof(GetCompany), new { companyId = createdCompany.CompanyId }, createdCompany);
            return Ok(createdCompany);
        }   


        [HttpPut("UpdateCompany/{companyId}")]
        public async Task<IActionResult> UpdateCompany([FromRoute]int companyId, [FromBody] CreateCompanyVM companyVM)
        {
            var updatedCompany = await _companyService.UpdateCompanyAsync(companyId, companyVM);
            if (updatedCompany == null)
                return NotFound();
            return Ok(updatedCompany);
        }


        [HttpDelete("DeleteCompany/{companyId}")]
        public async Task<IActionResult> DeleteCompany([FromRoute]int companyId)
        {
            var result = await _companyService.DeleteCompanyAsync(companyId);
            if (!result)
            {
                return NotFound();
            }
            var apiResponse = new APIResponseVM<object>()
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = StringConstants.CreateSuccess,
            };
            return Ok(apiResponse);
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> EditCompanyPatch(int id, [FromBody] JsonPatchDocument<Company> companyPatch)
        {
            var success = await _companyService.UpdateCompanyWithPatchAsync(id, companyPatch);
            if (!success)
            {
                return NotFound();
            }

            return Ok(new { message = StringConstants.CreateSuccess });
        }






        /*[HttpPost("{companyId}/cars")]
        public async Task<IActionResult> AddCar(int companyId, [FromBody] CarVM carVM)
        {
            var addedCar = await _companyService.AddCarAsync(companyId, carVM);
            if (addedCar == null)
                return NotFound();
            return CreatedAtAction(nameof(GetCompany), new { companyId = companyId, carId = addedCar.CarId }, addedCar);
        }*/

        /*  [HttpPut("{companyId}/cars/{carId}")]
          public async Task<IActionResult> UpdateCar(int companyId, int carId, [FromBody] CarVM carVM)
          {
              var updatedCar = await _companyService.UpdateCarAsync(companyId, carId, carVM);
              if (updatedCar == null)
                  return NotFound();
              return Ok(updatedCar);
          }*/

        /*[HttpDelete("{companyId}/cars/{carId}")]
        public async Task<IActionResult> DeleteCar(int companyId, int carId)
        {
            var result = await _companyService.DeleteCarAsync(companyId, carId);
            if (!result)
                return NotFound();
            return NoContent();
        }*/
    }
}
