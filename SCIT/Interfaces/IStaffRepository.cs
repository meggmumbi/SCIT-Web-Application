using SCIT.Entities;

namespace SCIT.Interfaces
{
    public interface IStaffRepository
    {
        Task<Staff> GetByIdAsync(Guid id);
        Task<List<Staff>> GetAllAsync();
        Task AddAsync(Staff staff);
        Task UpdateAsync(Staff staff);
        Task DeleteAsync(Guid id);
    }
}
