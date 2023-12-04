using Domain.Enums;
using System.ComponentModel.DataAnnotations;
namespace Api.Model.Employee
{
    public class PersonUpdateModel
    {
        [Required(ErrorMessage = "ارسال نام اجباری می باشد")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "ارسال نام خانوادگی اجباری می باشد")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "ارسال کد ملی اجباری می باشد")]
        public string NationalCode { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? FatherName { get; set; }

        [Required(ErrorMessage = "ارسال کد پرسنلی اجباری می باشد")]
        public string PersonalNumber { get; set; }
        public Gender? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? IdentityNumber { get; set; }

        [Required(ErrorMessage = "ارسال وضعیت اجباری می باشد")]
        public bool IsActive { get; set; }
        public DateTime? EmployeementDate { get; set; }
        public decimal? WorkingHoursRate { get; set; }
        public string? ImageUrl { get; set; }
        public string? DigitalSignatureUrl { get; set; }
        public string? OrganizationalPost { get; set; }

        [Required(ErrorMessage = "ارسال سمت اجباری می باشد")]
        public List<int> PostId { get; set; }
        //public int BiUnitId { get; set; }
    }
}
