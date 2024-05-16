using CarManagement.Data.Context;
using CarManagement.Data.IRepository;
using CarManagement.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarManagement.Data.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly CarManagementContext _context;
        public CompanyRepository(CarManagementContext context)
        {
           _context = context;
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            return await _context.Companys.FirstOrDefaultAsync(i => i.CompanyId == id);
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await _context.Companys.FromSqlRaw("EXEC GetAllCompanyList").ToListAsync();
        }

        public async Task<IEnumerable<Company>> FindAsync(Expression<Func<Company, bool>> predicate)
        {
            return await _context.Companys.Where(predicate).ToListAsync();
        }

        public async Task<Company> AddAsync(Company company)
        {
            await _context.AddAsync(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<Company> UpdateAsync(Company company)
        {
            _context.Entry(company).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<bool> DeleteAsync(Company company)
        {
            _context.Companys.Remove(company);
            int affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0;
        }

        public async Task<bool> UpdateCompanyWithPatchAsync(Company company)
        {
            _context.Companys.Update(company);
            await _context.SaveChangesAsync();
            return true; 
        }
    }
}
