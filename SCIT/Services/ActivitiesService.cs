using SCIT.Entities;
using SCIT.Interfaces;

namespace SCIT.Services
{
    public class ActivitiesService
    {
        private readonly IActivitiesRepository _repository;

        public ActivitiesService(IActivitiesRepository repository)
        {
            _repository = repository;
        }

        public async Task<Activities> GetActivityByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<Activities>> GetAllActivitiesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddActivityAsync(Activities activity)
        {
            await _repository.AddAsync(activity);
        }

        public async Task UpdateActivityAsync(Activities activity)
        {
            await _repository.UpdateAsync(activity);
        }

        public async Task DeleteActivityAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
