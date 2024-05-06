using Microsoft.EntityFrameworkCore;
using SCIT.Data;
using SCIT.Entities;
using SCIT.Interfaces;

namespace SCIT.Repositories
{
    public class ProgrammesRepository : IProgrammesRepository
    {
        private readonly AppDbContext _dbContext;

        public ProgrammesRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Programmes programme)
        {
            _dbContext.Programmes.Add(programme);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var programme = await GetByIdAsync(id);
            if (programme != null)
            {
                _dbContext.Programmes.Remove(programme);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Programmes>> GetAllAsync()
        {
            return await _dbContext.Programmes.ToListAsync();
        }

        public async Task<Programmes> GetByIdAsync(Guid id)
        {
            return await _dbContext.Programmes.FindAsync(id);
        }

        public async Task UpdateAsync(Programmes programme)
        {
            _dbContext.Entry(programme).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
