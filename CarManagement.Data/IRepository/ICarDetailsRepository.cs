using CarManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Data.IRepository
{
    public interface ICarDetailsRepository
    {
        Task<CarDetails> GetCarDetailsByCarId(int id);
        Task<IEnumerable<CarDetails>> GetAllCarDetailAsync();
        Task<CarDetails> AddCarDetailAsync(CarDetails car);
        Task<CarDetails> GetCarDetailById(int id);
        Task<CarDetails> UpdateAsync(CarDetails carDetail);
        Task <bool> DeleteCarDetailAsync(CarDetails carDetails);
        
    }
}
