using Microsoft.EntityFrameworkCore;
using SCIT.Data;
using SCIT.Entities;
using SCIT.Interfaces;

namespace SCIT.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly AppDbContext _dbContext;

        public StaffRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(Staff staff)
        {
            _dbContext.Staff.Add(staff);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var staff = await GetByIdAsync(id);
            if (staff != null)
            {
                _dbContext.Staff.Remove(staff);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Staff>> GetAllAsync()
        {
            return await _dbContext.Staff.ToListAsync();
        }

        public async Task<Staff> GetByIdAsync(Guid id)
        {
            return await _dbContext.Staff.FindAsync(id);
        }

        public async Task UpdateAsync(Staff staff)
        {
            _dbContext.Entry(staff).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
