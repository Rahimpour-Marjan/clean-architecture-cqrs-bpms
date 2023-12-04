using Domain.Enums;

namespace Domain
{
    public class Person
    {
        public Person(string firstName, string lastName, UserType userType,
            string nationalCode, string? phone,
            string? email, string? fatherName,  
            string personalNumber, Gender? gender,
            DateTime? birthDate, string? identityNumber, bool isActive,
            DateTime? employeementDate,
            decimal? workingHoursRate,
            string? imageUrl,
            string? digitalSignatureUrl,
            string? organizationalPost,
            int postCount)
        {
            FirstName = firstName;
            LastName = lastName;
            UserType = userType;
            NationalCode = nationalCode;
            Phone = phone;
            Email = email;
            FatherName = fatherName;
            PersonalNumber = personalNumber;
            Gender = gender;
            BirthDate = birthDate;
            IdentityNumber = identityNumber;
            IsActive = isActive;
            EmployeementDate = employeementDate;
            WorkingHoursRate = workingHoursRate;
            ImageUrl = imageUrl;
            DigitalSignatureUrl = digitalSignatureUrl;
            OrganizationalPost=organizationalPost;
            PostCount = postCount;
        }
        protected Person()
        {
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserType? UserType { get; set; }
        public string NationalCode { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? FatherName { get; set; }
        public string PersonalNumber { get; set; }
        public Gender? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? IdentityNumber { get; set; }
        public bool IsActive { get; set; }
        public DateTime? EmployeementDate { get; set; }
        public decimal? WorkingHoursRate { get; set; }
        public string? ImageUrl { get; set; }
        public string? DigitalSignatureUrl { get; set; }
        public string? OrganizationalPost { get; set; }
        public int PostCount { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Calendar> Calendars { get; set; }
        public virtual ICollection<CalendarReceiver> CalendarReceivers { get; set; }
        public virtual ICollection<PersonJuncPost> PersonJuncPosts { get; set; }
    }
}
