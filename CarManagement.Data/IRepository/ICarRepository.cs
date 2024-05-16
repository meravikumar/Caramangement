using CarManagement.Data.Models;
using System.Linq.Expressions;

namespace CarManagement.Data.IRepository
{
    public interface ICarRepository
    {
        Task<List<Car>> GetCarByCompanyIdAsync(int id);
        Task<IEnumerable<Car>> GetAllCarAsync();
        Task<Car> GetCarByIdAsync(int id);
        Task<IEnumerable<Car>> FindAsync(Expression<Func<Car, bool>> predicate);
        Task<Company> GetCompanyAsyncByID(int id);
        Task<Car> AddCarAsync(Car car);
        Task<Car> UpdateAsync(Car car);
        Task<bool> DeleteAsync(Car car);
        Task<bool> UpdateCarWithPatchAsync(Car car);
    }
}
