using CarManagement.Core.ViewModels.Cars;
using CarManagement.Core.ViewModels.Companies;
using CarManagement.Data.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Business.IServices
{
    public interface ICompanyService
    {
        Task<CompanyVM> GetCompanyAsyncByID(int companyId);
        Task<List<Company>> GetAllAsync();
        Task<Company> CreateCompanyAsync(CreateCompanyVM createCompanyVM);
        Task<CreateCompanyVM> UpdateCompanyAsync(int companyId, CreateCompanyVM companyVM);
        Task<bool> DeleteCompanyAsync(int companyId);
        Task<CarVM> AddCarAsync(int companyId, CarVM carVM);
        Task<CarVM> UpdateCarAsync(int companyId, int carId, CarVM carVM);
        Task<bool> DeleteCarAsync(int companyId, int carId);
        Task<bool> UpdateCompanyWithPatchAsync(int id, JsonPatchDocument<Company> company);
    }
}
