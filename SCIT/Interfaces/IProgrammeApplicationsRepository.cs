using SCIT.Entities;

namespace SCIT.Interfaces
{
    public interface IProgrammeApplicationsRepository
    {
        Task<ProgrammeApplications> GetByIdAsync(Guid id);
        Task<List<ProgrammeApplications>> GetAllAsync();
        Task AddAsync(ProgrammeApplications applications);
        Task UpdateAsync(ProgrammeApplications applications);
        Task DeleteAsync(Guid id);
    }
}
