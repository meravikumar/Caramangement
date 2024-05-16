using CarManagement.Data.Context;
using CarManagement.Data.IRepository;
using CarManagement.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarManagement.Data.Repository
{
    public class CarRepository: ICarRepository
    {
        private readonly CarManagementContext _context;
        //private readonly DbSet<TEntity> _dbSet;

        public CarRepository(CarManagementContext context)
        {
            _context = context;
           
        }
        public async Task<Car> AddCarAsync(Car car)
        {
            await _context.AddAsync(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<bool> DeleteAsync(Car car)
        {
            _context.Remove(car);
            await _context.SaveChangesAsync();
            return true;
        }
        

        public Task<IEnumerable<Car>> FindAsync(Expression<Func<Car, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Car>> GetAllCarAsync()
        {
            return await _context.Cars
                                 .Include(c => c.Company)
                                 .ToListAsync();
        }

       public async Task<List<Car>> GetCarByCompanyIdAsync(int id)
        {
            var result= _context.Cars.Where(c=>c.CompanyId==id).ToList();
            return result;
                
        }

        public async Task<Car?> GetCarByIdAsync(int id)
        {
            return await _context.Cars
                                .Include(c => c.CarDetails)
                                .FirstOrDefaultAsync(d => d.CarId == id);
        }


        public async Task<Company> GetCompanyAsyncByID(int id)
        {
            return await _context.Companys.Where(c=>c.CompanyId == id).AsNoTracking().FirstAsync();
        }

        public async Task<Car> UpdateAsync(Car entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateCarWithPatchAsync(Car car)
        {
            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
