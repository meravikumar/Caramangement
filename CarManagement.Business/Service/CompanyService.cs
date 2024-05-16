using AutoMapper;
using CarManagement.Business.IServices;
using CarManagement.Core.ViewModels.Cars;
using CarManagement.Core.ViewModels.Companies;
using CarManagement.Data.IRepository;
using CarManagement.Data.Models;
using Microsoft.AspNetCore.JsonPatch;
namespace CarManagement.Business.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, ICarRepository carRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<CompanyVM> GetCompanyAsyncByID(int companyId)
        {
            var company = await _companyRepository.GetByIdAsync(companyId);
            var car = await _carRepository.GetCarByCompanyIdAsync(companyId);
            if (company == null)
                return null;

            // ECars  null before selecting car VMs
            if (company.Cars == null)
            {
                company.Cars = new List<Car>();
            }

            return new CompanyVM
            {
                CompanyId = company.CompanyId,
                CompanyName = company.CompanyName,
                Location = company.Location,
                CEO = company.CEO,
                IsFinanceProvider = company.IsFinanceProvider,
                EstablishedDate = company.EstablishedDate,
                Cars = company.Cars.Select(c => new CarVM
                {
                    CarId = c.CarId,
                    CarName = c.CarName,
                    Price = c.Price,
                    CarModel = c.CarModel,
                    Insurance = c.Insurance
                }).ToList()
            };
        }

        public async Task<Company> CreateCompanyAsync(CreateCompanyVM createCompanyVM)
        {
            var company = new Company
            {
                CompanyName = createCompanyVM.CompanyName,
                Location = createCompanyVM.Location,
                CEO = createCompanyVM.CEO,
                IsFinanceProvider = createCompanyVM.IsFinanceProvider,
                EstablishedDate = createCompanyVM.EstablishedDate.HasValue ? DateOnly.FromDateTime(createCompanyVM.EstablishedDate.Value) : DateOnly.MinValue
            };

            await _companyRepository.AddAsync(company);

            return company;
        }

        public async Task<CreateCompanyVM> UpdateCompanyAsync(int companyId, CreateCompanyVM companyVM)
        {
            var existingCompany = await _companyRepository.GetByIdAsync(companyId);
            if (existingCompany == null)
                return null; 

            existingCompany.CompanyName = companyVM.CompanyName;
            existingCompany.Location = companyVM.Location;
            existingCompany.CEO = companyVM.CEO;
            existingCompany.IsFinanceProvider = companyVM.IsFinanceProvider;
            existingCompany.EstablishedDate = companyVM.EstablishedDate.HasValue ? DateOnly.FromDateTime(companyVM.EstablishedDate.Value) : DateOnly.MinValue;

            await _companyRepository.UpdateAsync(existingCompany);

            return companyVM; 
        }

        public async Task<bool> DeleteCompanyAsync(int companyId)
        {
            var existingCompany = await _companyRepository.GetByIdAsync(companyId);
            if (existingCompany == null)
            {
                return false;
            }
            await _companyRepository.DeleteAsync(existingCompany);
            return true; 
        }

        public async Task<CarVM> AddCarAsync(int companyId, CarVM carVM)
        {
            var company = await _companyRepository.GetByIdAsync(companyId);
            if (company == null)
            {
                return null;
            }
            var car = new Car
            {
                CarName = carVM.CarName,
                Price = carVM.Price,
                CarModel = carVM.CarModel,
                Insurance = carVM.Insurance
            };

            company.Cars.Add(car);
            await _companyRepository.UpdateAsync(company);
            return carVM;
        }

        public async Task<CarVM> UpdateCarAsync(int companyId, int carId, CarVM carVM)
        {
            var company = await _companyRepository.GetByIdAsync(companyId);
            if (company == null)
            {
                return null;
            }
            var existingCar = company.Cars.FirstOrDefault(c => c.CarId == carId);
            if (existingCar == null)
            {
                return null;
            }
            existingCar.CarName = carVM.CarName;
            existingCar.Price = carVM.Price;
            existingCar.CarModel = carVM.CarModel;
            existingCar.Insurance = carVM.Insurance;
            await _companyRepository.UpdateAsync(company);
            return carVM; 
        }

        public async Task<bool> DeleteCarAsync(int companyId, int carId)
        {
            var company = await _companyRepository.GetByIdAsync(companyId);
            if (company == null)
                return false;

            var existingCar = company.Cars.FirstOrDefault(c => c.CarId == carId);
            if (existingCar == null)
                return false;

            company.Cars.Remove(existingCar);
            await _companyRepository.UpdateAsync(company);

            return true;
        }

        public async Task<List<Company>> GetAllAsync()
        {
            var result = await _companyRepository.GetAllAsync();
            //var VMs = _mapper.Map<List<CreateCompanyVM>>(result);
            return result.ToList();
        }


        public async Task<bool> UpdateCompanyWithPatchAsync(int id, JsonPatchDocument<Company> companyPatch)
        {
            var result = await _companyRepository.GetByIdAsync(id);
            if (result == null)
            {
                return false;
            }

            companyPatch.ApplyTo(result);
            return await _companyRepository.UpdateCompanyWithPatchAsync(result);
        }

    }
}
