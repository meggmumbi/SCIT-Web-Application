namespace SCIT.Entities
{
    public class Programmes
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string ProgrammeType { get; set; }
        public string Description { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid? StaffId { get; set; }

    }
}
