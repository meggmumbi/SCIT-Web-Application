namespace SCIT.Entities
{
    public class Staff
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? DepartmentId { get; set; }
        public string Specializations { get; set;}
        public string Title { get; set;}
        public string StaffType { get; set;}


        public string Designation { get; set;}
        public DateTime Dob { get; set; }
        public string Gender { get; set; }
    }
}
