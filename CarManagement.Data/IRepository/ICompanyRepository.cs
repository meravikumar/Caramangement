using CarManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Data.IRepository
{
    public interface ICompanyRepository
    {
        Task<Company> GetByIdAsync(int id);
        Task<IEnumerable<Company>> GetAllAsync();
        Task<IEnumerable<Company>> FindAsync(Expression<Func<Company, bool>> predicate);
        Task<Company> AddAsync(Company company);
        Task<Company> UpdateAsync(Company company);
        Task<bool> DeleteAsync(Company company);
        Task<bool> UpdateCompanyWithPatchAsync(Company company);

    }
}
