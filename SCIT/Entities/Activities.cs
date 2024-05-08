namespace SCIT.Entities
{
    public class Activities
    {
        public Guid Id { get; set; }
        public string ActivityName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        public string Status { get; set; }

        public string Description { get; set; }

        public string ActivityType { get; set; }
    }
}
