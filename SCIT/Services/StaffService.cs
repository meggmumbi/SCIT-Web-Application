using SCIT.Entities;
using SCIT.Interfaces;

namespace SCIT.Services
{
    public class StaffService
    {
        private readonly IStaffRepository _repository;

        public StaffService(IStaffRepository repository)
        {
            _repository = repository;
        }

        public async Task<Staff> GetStaffByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<Staff>> GetAllStaffAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddStaffAsync(Staff staff)
        {
            await _repository.AddAsync(staff);
        }

        public async Task UpdateStaffAsync(Staff staff)
        {
            await _repository.UpdateAsync(staff);
        }

        public async Task DeleteStaffAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
