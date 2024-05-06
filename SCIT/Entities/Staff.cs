namespace SCIT.Entities
{
    public class Staff
    {
        public Guid Id { get; set; }
        public string StaffName { get; set; }
        public Guid DepartmentId { get; set; }
        public string Qualifications { get; set;}

        public string Designation { get; set;}
        public DateTime Dob { get; set; }
        public string Gender { get; set; }
    }
}
