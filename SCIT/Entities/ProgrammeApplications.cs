namespace SCIT.Entities
{
    public class ProgrammeApplications
    {
        public Guid Id { get; set; }
        public Guid ProgrammeId { get; set; }
        public string FullName { get; set; }    
        public DateTime Dob {  get; set; }

        public string ApprovalStatus { get; set; }

        public string IdNumber { get; set; }

        public string Status { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Qualifications { get; set; }
        public string PaymentMethod { get; set; }

    }
}
