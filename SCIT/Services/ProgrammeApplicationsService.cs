using SCIT.Entities;
using SCIT.Interfaces;

namespace SCIT.Services
{
    public class ProgrammeApplicationsService
    {
        private readonly IProgrammeApplicationsRepository _repository;

        public ProgrammeApplicationsService(IProgrammeApplicationsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProgrammeApplications> GetApplicationByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<ProgrammeApplications>> GetAllApplicationsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddApplicationAsync(ProgrammeApplications applications)
        {
            await _repository.AddAsync(applications);
        }

        public async Task UpdateApplicationAsync(ProgrammeApplications applications)
        {
            await _repository.UpdateAsync(applications);
        }

        public async Task DeleteApplicationAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
