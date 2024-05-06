using Microsoft.EntityFrameworkCore;
using SCIT.Data;
using SCIT.Entities;
using SCIT.Interfaces;

namespace SCIT.Repositories
{
    public class ActivitiesRepository : IActivitiesRepository
    {
        private readonly AppDbContext _dbContext;

        public ActivitiesRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(Activities activity)
        {
            _dbContext.Activities.Add(activity);
            await _dbContext.SaveChangesAsync();
            
        }

        public async Task DeleteAsync(Guid id)
        {
            var activity = await GetByIdAsync(id);
            if (activity != null)
            {
                _dbContext.Activities.Remove(activity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Activities>> GetAllAsync()
        {
            return await _dbContext.Activities.ToListAsync();
        }

        public async Task<Activities> GetByIdAsync(Guid id)
        {
            return await _dbContext.Activities.FindAsync(id);
        }

        public async Task UpdateAsync(Activities activity)
        {
            _dbContext.Entry(activity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
