using CarManagement.Business.IServices;
using CarManagement.Core.ViewModels.CarDetails;
using CarManagement.Core.ViewModels.Cars;
using CarManagement.Data.IRepository;
using CarManagement.Data.Models;
using CarManagement.Data.Repository;
using Microsoft.AspNetCore.JsonPatch;

namespace CarManagement.Business.Service
{
    public class CarServices : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly ICarDetailsRepository _carDetailRepository;
       
        public CarServices(ICarRepository carRepository,ICarDetailsRepository carDetailsRepository)
        {
            _carRepository = carRepository;
            _carDetailRepository = carDetailsRepository;
        }
        public Task<CarVM> AddCarAsync(int companyId, CarVM carVM)
        {
            throw new NotImplementedException();
        }

        public async Task<Car> CreateCarAsync(CreateCarVM createCarVM)
        {
            var car = new Car()
            {
                CarName= createCarVM.CarName,
                CarModel= createCarVM.CarModel,
                Insurance= createCarVM.Insurance,
                Price= createCarVM.Price,
                CompanyId= createCarVM.CompanyId,
            };
            if(createCarVM.CarModel == null)
            {
                return null;
            }
            await _carRepository.AddCarAsync(car);
            return car;
        }

        public Task<bool> DeleteCarAsync(int companyId, int carId)
        {
            throw new NotImplementedException();
        }

        public  async Task<bool> DeleteCarAsync(int carId)
        {
            var carToDelete = await _carRepository.GetCarByIdAsync(carId);
            if(carToDelete == null)
            {
                return false;
            }
            await _carRepository.DeleteAsync(carToDelete);
            return true;
        }

        public Task<bool> DeleteCompanyAsync(int companyId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CarListVM>> GetAllCarsAsync()
        {
            var cars = await _carRepository.GetAllCarAsync();
            return cars.Select(car => new CarListVM
            {
                CarId = car.CarId,
                CarName = car.CarName,
                Price = car.Price,
                CarModel = car.CarModel,
                Insurance = car.Insurance,
                Company = car.Company != null ? car.Company.CompanyName : null
            }).ToList();
        }

        public async Task<CarByIdWithDetailsVM> GetCarByIdAsync(int carId)
        {
            var car = await _carRepository.GetCarByIdAsync(carId);
            if (car == null)
            {
                return null;
            }
            var carVM = new CarByIdWithDetailsVM
            {
                CarId = car.CarId,
                CarName = car.CarName,
                Price = car.Price,
                CarModel = car.CarModel,
                Insurance = car.Insurance,
                CarDetail = new CarDetailVM
                {
                    // Access details directly from the car object
                    CarDetail_Id = car.CarDetails.CarDetail_Id,
                    Engine = car.CarDetails.Engine,
                    NumberOfAirbags = car.CarDetails.NumberOfAirbags,
                    SafetRating = car.CarDetails.SafetRating,
                    Type = car.CarDetails.Type,
                    Weight = car.CarDetails.Weight
                }
            };

            return carVM;
        }

        public Task<CarVM> GetCompanyAsync(int companyId)
        {
            throw new NotImplementedException();
        }

        public Task<CarVM> UpdateCarAsync(int companyId, int carId, CarVM carVM)
        {
            throw new NotImplementedException();
        }

        public async Task<CreateCarVM> UpdateCarAsync(int carId, CreateCarVM carVM)
        {
            var existingCar= await _carRepository.GetCarByIdAsync(carId);
            if (existingCar == null)
            {
                return null;
            }
            existingCar.CarName = carVM.CarName;
            existingCar.Price = carVM.Price;
            existingCar.Insurance = carVM.Insurance;
            existingCar.CarModel = carVM.CarModel;
            existingCar.CompanyId = carVM.CompanyId;
            await _carRepository.UpdateAsync(existingCar);
            return carVM;
        }

        public Task<CarVM> UpdateCompanyAsync(int companyId, CarVM companyVM)
        {
            throw new NotImplementedException();
        }


        public async Task<bool> UpdateCarWithPatchAsync(int id, JsonPatchDocument<Car> carPatch)
        {
            var result = await _carRepository.GetCarByIdAsync(id);
            if (result == null)
            {
                return false;
            }

            carPatch.ApplyTo(result);
            return await _carRepository.UpdateCarWithPatchAsync(result);
        }
    }
}
