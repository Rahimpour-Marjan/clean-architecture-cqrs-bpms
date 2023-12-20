using Domain.Enums;

namespace Domain
{
    public class Account
    {
        protected Account()
        {
        }

        public Account(string firstName, string lastName, UserType userType,
            Gender? gender, DateTime? birthDate, string? nationalCode, string? phone,
            string? extraPhone1, string? extraPhone2, string? extraPhone3,
            string? email, string? extraEmail, string? fax, string? website,
            string? instagram, string? telegram, string? whatsApp, string? linkedin, string? facebook,
            int ? countryId, int? stateId, int? cityId, int? zoneId, string? address, string? locationLong, string? locationLat,
            string? job, string? company, string? companyNo, 
            string? fatherName,
            string? AccountalNumber,bool isActive,
            decimal? workingHoursRate,
            string? reagentName, string? reagentCode,
            string? imageUrl,
            string? digitalSignatureUrl,
            string? resumeUrl,
            bool spacialAccount,bool isPublic,
            int? packageId, int? educationSubFieldId, int? educationLevelId,
            DateTime? employeementDate,DateTime? modifiedDate)
        {
            FirstName = firstName;
            LastName = lastName;
            UserType = userType;
            Gender = gender;
            BirthDate = birthDate;
            NationalCode = nationalCode;
            Phone = phone;
            ExtraPhone1 = extraPhone1;
            ExtraPhone2 = extraPhone2;
            ExtraPhone3 = extraPhone3;
            Email = email;
            ExtraEmail = extraEmail;
            Fax = fax;
            Website = website;
            Instagram = instagram;
            Telegram = telegram;
            WhatsApp = whatsApp;
            Linkedin = linkedin;
            Facebook = facebook;
            CountryId = countryId;
            StateId = stateId;
            CityId = cityId;
            ZoneId = zoneId;
            Address = address;
            LocationLong = locationLong;
            LocationLat = locationLat;
            Job = job;
            Company = company;
            CompanyNo = companyNo;
            FatherName = fatherName;
            AccountalNumber = AccountalNumber;
            IsActive = isActive;
            WorkingHoursRate = workingHoursRate;
            ReagentName = reagentName;
            ReagentCode = reagentCode;
            ImageUrl = imageUrl;
            DigitalSignatureUrl = digitalSignatureUrl;
            ResumeUrl = resumeUrl;
            SpacialAccount = spacialAccount;
            IsPublic = isPublic;
            PackageId = packageId;
            EducationSubFieldId = educationSubFieldId;
            EducationLevelId = educationLevelId;
            EmployeementDate = employeementDate;
            ModifiedDate = modifiedDate;
            CreateDate = DateTime.Now;

        }
        
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
        public Country? Country { get; set; }

        public int? StateId { get; set; }
        public State? State { get; set; }

        public int? CityId { get; set; }
        public City? City { get; set; }

        public int? ZoneId { get; set; }
        public Zone? Zone { get; set; }

        public string? Address { get; set; }
        public string? LocationLong { get; set; }
        public string? LocationLat { get; set; }
        public string? Job { get; set; }
        public string? Company { get; set; }
        public string? CompanyNo { get; set; }
        public string? FatherName { get; set; }
        public string? AccountalNumber { get; set; }
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
        public Package? Package { get; set; }

        public int? EducationSubFieldId { get; set; }
        public EducationSubField? EducationSubField { get; set; }

        public int? EducationLevelId { get; set; }
        public EducationLevel? EducationLevel { get; set; }

        public DateTime? EmployeementDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? CreateDate { get; set; }
       
       
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Calendar> Calendars { get; set; }
        public virtual ICollection<CalendarReceiver> CalendarReceivers { get; set; }
        public virtual ICollection<AccountJuncPost> AccountJuncPosts { get; set; }
        public virtual ICollection<AccountAddress> AccountAddresses { get; set; }
        public virtual ICollection<AccountCheck> AccountChecks { get; set; }
        public virtual ICollection<AccountCredit> AccountCredits { get; set; }
        public virtual ICollection<CreditPayment> CreditPayments { get; set; }
    }
}
