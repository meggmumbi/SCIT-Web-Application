namespace SCIT.Entities
{
    public class Activities
    {
        public Guid Id { get; set; }
        public string ActivityName { get; set; }
        public string ActivityType { get; set; }
        public string? Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; } 

        public string Description { get; set; }
        public string? Image { get; set; }
        public string? Mission { get; set; }
        public string? Vision { get; set; }
    }
}
