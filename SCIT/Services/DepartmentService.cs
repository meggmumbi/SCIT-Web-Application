using SCIT.Entities;
using SCIT.Interfaces;

namespace SCIT.Services
{
    public class DepartmentService
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentService(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Department> GetDepartmentByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddDepartmentAsync(Department department)
        {
            await _repository.AddAsync(department);
        }

        public async Task UpdateDepartmentAsync(Department department)
        {
            await _repository.UpdateAsync(department);
        }

        public async Task DeleteDepartmentAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
