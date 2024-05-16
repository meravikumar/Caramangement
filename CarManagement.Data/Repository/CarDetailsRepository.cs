using CarManagement.Data.Context;
using CarManagement.Data.IRepository;
using CarManagement.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Data.Repository
{
    public class CarDetailsRepository : ICarDetailsRepository
    {
        private readonly CarManagementContext _context;
        

        public CarDetailsRepository(CarManagementContext context)
        {
            _context = context;
        }

        public async Task<CarDetails> GetCarDetailsByCarId(int id)
        {
            var carDetails = await _context.Details.FirstOrDefaultAsync(cd => cd.CarId == id);

            if (carDetails == null)
            {
                throw new InvalidOperationException($"Car details with ID {id} not found.");
            }

            return carDetails;
        }

        public async Task<CarDetails> AddCarDetailAsync(CarDetails car)
        {
            await _context.AddAsync(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<CarDetails ?> GetCarDetailById(int id)
        {
            return await _context.Details.FirstOrDefaultAsync(c => c.CarDetail_Id == id);
        }

        public async Task<CarDetails> UpdateAsync(CarDetails carDetail)
        {
            _context.Entry(carDetail).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return carDetail;
        }

        public async Task<bool> DeleteCarDetailAsync(CarDetails carDetails)
        {
             _context.Details.Remove(carDetails);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CarDetails>> GetAllCarDetailAsync()
        {
             return await _context.Details.ToListAsync();
        }
    }
}
