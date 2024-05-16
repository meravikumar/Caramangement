using CarManagement.Core.ViewModels.CarDetails;
using CarManagement.Core.ViewModels.CarDetails;
using CarManagement.Core.ViewModels.Cars;
using CarManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Business.IServices
{
    public interface ICarDetailService
    {
        Task<CarDetails> CreateCarDetailAsync(CreateCarDetailVM createCarDetailVM);
        Task<EditCarDetailVM> UpdateCarDetailAsync(int carId, EditCarDetailVM editCarDetailVM);
        Task<bool> DeleteCarDetailAsync(int carDetailId);
        Task<List<CarDetails>> GetAllCarDetailAsync();
        Task<CarDetails> GetCarDetailByIdAsync(int carDetailId);

    }
}
