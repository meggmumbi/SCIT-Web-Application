using SCIT.Entities;
using SCIT.Interfaces;

namespace SCIT.Services
{
    public class ProgrammesService
    {
        private readonly IProgrammesRepository _repository;

        public ProgrammesService(IProgrammesRepository repository)
        {
            _repository = repository;
        }

        public async Task<Programmes> GetProgrammeByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<Programmes>> GetAllProgrammesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddProgrammeAsync(Programmes programme)
        {
            await _repository.AddAsync(programme);
        }

        public async Task UpdateProgrammeAsync(Programmes programme)
        {
            await _repository.UpdateAsync(programme);
        }

        public async Task DeleteProgrammeAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
