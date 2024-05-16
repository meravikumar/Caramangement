using CarManagement.Business.IServices;
using CarManagement.Core.ViewModels.CarDetails;
using CarManagement.Core.ViewModels.Cars;
using CarManagement.Data.IRepository;
using CarManagement.Data.Models;
using CarManagement.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Business.Service
{
    public class CarDetailService : ICarDetailService
    {
        private readonly ICarDetailsRepository _carDetailsRepository;
        public CarDetailService(ICarDetailsRepository carDetailsRepository)
        {
            _carDetailsRepository = carDetailsRepository;
        }

        public async Task<List<CarDetails>> GetAllCarDetailAsync()
        {
           return (List<CarDetails>)await _carDetailsRepository.GetAllCarDetailAsync();

        }

        public async Task<CarDetails> GetCarDetailByIdAsync(int carDetailId)
        {
            var detail =await _carDetailsRepository.GetCarDetailById(carDetailId);
            if(detail == null)
            {
                return null;
            }
            return detail;
        }

        public async Task<CarDetails> CreateCarDetailAsync(CreateCarDetailVM createCarDetailVM)
        {
            if (createCarDetailVM == null)
            {
                return null;
            }
            var carDetail = new CarDetails()
            {
                Engine = createCarDetailVM.Engine,
                NumberOfAirbags = createCarDetailVM.NumberOfAirbags,
                Type = createCarDetailVM.Type,
                Weight = createCarDetailVM.Weight,
                SafetRating = createCarDetailVM.SafetRating,
                CarId = createCarDetailVM.CarId

            };
            if (carDetail==null)
            {
                return null;
            }
            await _carDetailsRepository.AddCarDetailAsync(carDetail);
            return carDetail;
        }

        public async Task<bool> DeleteCarDetailAsync(int carDetailId)
        {
           var carDetailToDelete = await _carDetailsRepository.GetCarDetailById(carDetailId);
            if (carDetailToDelete == null)
            {
                return false;
            }
            await _carDetailsRepository.DeleteCarDetailAsync(carDetailToDelete);
            return true;

        }

        public async Task<EditCarDetailVM> UpdateCarDetailAsync(int carDetailId,EditCarDetailVM editCarDetailVM)
        {
            var existingDetail= await _carDetailsRepository.GetCarDetailById(carDetailId);
            if (existingDetail== null)
            {
                return null;
            }
            existingDetail.Engine = editCarDetailVM.Engine;
            existingDetail.NumberOfAirbags = editCarDetailVM.NumberOfAirbags;
            existingDetail.SafetRating = editCarDetailVM.SafetRating;   
            existingDetail.Weight = editCarDetailVM.Weight; 
            existingDetail.Type = editCarDetailVM.Type;
            return editCarDetailVM;
        }
    }
}
