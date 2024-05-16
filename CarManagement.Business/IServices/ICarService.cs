using CarManagement.Core.ViewModels.Cars;
using CarManagement.Data.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace CarManagement.Business.IServices
{
    public interface ICarService
    {
        Task<CarByIdWithDetailsVM> GetCarByIdAsync(int carId);
        Task<List<CarListVM>> GetAllCarsAsync();
        Task<CarVM> UpdateCompanyAsync(int carId, CarVM carVM);
        Task<bool> DeleteCarAsync(int carId);
        Task<CarVM> AddCarAsync(int carId, CarVM carVM);
        Task<CarVM> UpdateCarAsync(int companyId, int carId, CarVM carVM);
        Task<Car> CreateCarAsync(CreateCarVM createCarVM);
        Task <CreateCarVM> UpdateCarAsync(int carId, CreateCarVM carVM);
        Task<bool> UpdateCarWithPatchAsync(int id, JsonPatchDocument<Car> car);

    }
}
