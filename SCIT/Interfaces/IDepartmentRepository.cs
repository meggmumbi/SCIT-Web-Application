using SCIT.Entities;

namespace SCIT.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<Department> GetByIdAsync(Guid id);
        Task<List<Department>> GetAllAsync();
        Task AddAsync(Department department);
        Task UpdateAsync(Department department);
        Task DeleteAsync(Guid id);
    }
}
