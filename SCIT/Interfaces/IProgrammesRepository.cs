using SCIT.Entities;

namespace SCIT.Interfaces
{
    public interface IProgrammesRepository
    {

        Task<Programmes> GetByIdAsync(Guid id);
        Task<List<Programmes>> GetAllAsync();
        Task AddAsync(Programmes programme);
        Task UpdateAsync(Programmes programme);
        Task DeleteAsync(Guid id);
    }
}
