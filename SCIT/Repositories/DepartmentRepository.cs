using Microsoft.EntityFrameworkCore;
using SCIT.Data;
using SCIT.Entities;
using SCIT.Interfaces;
using System.Diagnostics;

namespace SCIT.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _dbContext;
        public DepartmentRepository(AppDbContext dbContext) {
            _dbContext = dbContext;

        }
        public async Task AddAsync(Department department)
        {
            _dbContext.Department.AddAsync(department);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var department  = await GetByIdAsync(id);
            if (department != null)
            {
                _dbContext.Department.Remove(department);
                await _dbContext.SaveChangesAsync();

            }
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await _dbContext.Department.ToListAsync();
        }

        public async Task<Department> GetByIdAsync(Guid id)
        {
            return await _dbContext.Department.FindAsync(id);
        }

        public async Task UpdateAsync(Department department)
        {
            _dbContext.Entry(department).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
