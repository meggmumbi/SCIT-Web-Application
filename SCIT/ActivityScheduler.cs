
using SCIT.Entities;
using SCIT.Interfaces;

namespace SCIT
{
    public class ActivityScheduler : BackgroundService
    {
        private readonly ILogger<ActivityScheduler> _logger;
        private readonly IActivitiesRepository _activitiesRepository;

        public ActivityScheduler(ILogger<ActivityScheduler> logger, IActivitiesRepository activitiesRepository)
        {
            _logger = logger;
            _activitiesRepository = activitiesRepository;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // Retrieve all activities
                var activities = await _activitiesRepository.GetAllAsync();

                foreach (var activity in activities)
                {
                    UpdateActivityStatus(activity);
                }

                // Wait for 1 minute before checking again
                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }
        private void UpdateActivityStatus(Activities activity)
        {
            var currentTime = DateTime.UtcNow;

            if (currentTime < activity.StartDate)
            {
                activity.Status = "Upcoming";
            }
            else if (currentTime >= activity.StartDate && currentTime <= activity.EndDate)
            {
                activity.Status = "Ongoing";
            }
            else
            {
                activity.Status = "Past";
            }

            // Update activity status in the repository
            _activitiesRepository.UpdateAsync(activity);
        }
    }
}
