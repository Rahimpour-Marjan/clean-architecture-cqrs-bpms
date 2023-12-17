
using Domain.Enums;

namespace Application.Person.Models
{
    public class PersonInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserType? UserType { get; set; }
        public Gender? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? NationalCode { get; set; }
        public string? Phone { get; set; }
        public string? ExtraPhone1 { get; set; }
        public string? ExtraPhone2 { get; set; }
        public string? ExtraPhone3 { get; set; }
        public string? Email { get; set; }
        public string? ExtraEmail { get; set; }
        public string? Fax { get; set; }
        public string? Website { get; set; }
        public string? Instagram { get; set; }
        public string? Telegram { get; set; }
        public string? WhatsApp { get; set; }
        public string? Linkedin { get; set; }
        public string? Facebook { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
        public int? ZoneId { get; set; }
        public string? Address { get; set; }
        public string? LocationLong { get; set; }
        public string? LocationLat { get; set; }
        public string? Job { get; set; }
        public string? Company { get; set; }
        public string? CompanyNo { get; set; }
        public string? FatherName { get; set; }
        public string? PersonalNumber { get; set; }
        public bool IsActive { get; set; }
        public decimal? WorkingHoursRate { get; set; }
        public string? ReagentName { get; set; }
        public string? ReagentCode { get; set; }
        public string? ImageUrl { get; set; }
        public string? DigitalSignatureUrl { get; set; }
        public string? ResumeUrl { get; set; }
        public bool SpacialAccount { get; set; }
        public bool IsPublic { get; set; }
        public int? PackageId { get; set; }
        public int? EducationFieldId { get; set; }
        public int? EducationLevelId { get; set; }

        public DateTime? EmployeementDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public List<Domain.Post> Posts { get; set; }
    }
}
