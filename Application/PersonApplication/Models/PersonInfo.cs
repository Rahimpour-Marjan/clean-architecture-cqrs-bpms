
namespace Application.Person.Models
{
    public class PersonInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? FatherName { get; set; }
        public string PersonalNumber { get; set; }
        public int? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? IdentityNumber { get; set; }
        public int? EmployeementType { get; set; }
        public bool IsActive { get; set; }
        public DateTime? EmployeementDate { get; set; }
        public decimal? WorkingHoursRate { get; set; }
        public string? ImageUrl { get; set; }
        public string? DigitalSignatureUrl { get; set; }
        public string? OrganizationalPost { get; set; }
        public int PostCount { get; set; }
        public List<Domain.Post> Posts { get; set; }
    }
}
