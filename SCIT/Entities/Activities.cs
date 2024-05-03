namespace SCIT.Entities
{
    public class Activities
    {
        public Guid ActivityId { get; set; }
        public string ActivityName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Message { get; set; }

        public string ActivityType { get; set; }
    }
}
