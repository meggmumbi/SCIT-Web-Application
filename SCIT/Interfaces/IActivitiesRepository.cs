using SCIT.Entities;

namespace SCIT.Interfaces
{
    public interface IActivitiesRepository
    {
        Task<Activities> GetByIdAsync(Guid id);
        Task<List<Activities>> GetAllAsync();
        Task AddAsync(Activities activity);
        Task UpdateAsync(Activities activity);
        Task DeleteAsync(Guid id);
    }
}
