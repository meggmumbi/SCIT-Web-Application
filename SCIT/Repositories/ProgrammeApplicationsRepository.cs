using Microsoft.EntityFrameworkCore;
using SCIT.Data;
using SCIT.Entities;
using SCIT.Interfaces;

namespace SCIT.Repositories
{
    public class ProgrammeApplicationsRepository : IProgrammeApplicationsRepository
    {
        private readonly AppDbContext _dbContext;

        public ProgrammeApplicationsRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(ProgrammeApplications applications)
        {
            _dbContext.ProgrammeApplications.AddAsync(applications);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
           var applications =  await GetByIdAsync(id);
           if(applications != null)
            {
                _dbContext.ProgrammeApplications.Remove(applications);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<ProgrammeApplications>> GetAllAsync()
        {
            return await _dbContext.ProgrammeApplications.ToListAsync();
        }

        public async Task<ProgrammeApplications> GetByIdAsync(Guid id)
        {
            return await _dbContext.ProgrammeApplications.FindAsync(id);
        }

        public async Task UpdateAsync(ProgrammeApplications applications)
        {
            _dbContext.Entry(applications).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
