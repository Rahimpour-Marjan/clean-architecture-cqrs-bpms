using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Enums
{
    public class Enums
    {
    }
    /// <summary>
    /// جنسیت
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// مذکر
        /// </summary>
        Male = 1,
        /// <summary>
        /// مونث
        /// </summary>
        Female = 2
    }
    public enum UserLogType
    {
        Login = 1,

        Logout = 2,
    }

    public enum CountUnit
    {
        [Display(Name = "گرم")]
        g,
        [Display(Name = "کیلوگرم")]
        kg,
        [Display(Name = "تن")]
        ton
    }

    /// <summary>
    /// نوع شرط فیلتر
    /// </summary>
    public enum ConditionType
    {
        /// <summary>
        /// مساوی
        /// </summary>
        Equal = 0,

        /// <summary>
        /// نامساوی
        /// </summary>
        NotEqual = 1,

        /// <summary>
        /// شامل
        /// </summary>
        Contains = 2,

        /// <summary>
        /// شامل نیست
        /// </summary>
        NotContains = 3,

        /// <summary>
        /// بزرگتر از
        /// </summary>
        GreaterThan = 4,

        /// <summary>
        /// بزرگتر مساوی
        /// </summary>
        GreaterThanEqual = 5,

        /// <summary>
        /// بزرگتر از
        /// </summary>
        LessThan = 6,

        /// <summary>
        /// بزرگتر مساوی
        /// </summary>
        LessThanEqual = 7,
        /// <summary>
        ///  قبل از
        /// </summary>
        BeforThan = 8,

        /// <summary>
        /// بعد از
        /// </summary>
        AfterThan = 9,

        /// <summary>
        /// بین
        /// </summary>
        Between = 10,
    }
    /// <summary>
    /// وضعیت تیکت
    /// </summary>
    public enum TicketStatus
    {
        [Display(Name = "در انتظار پاسخ")]
        AwaitingReview = 1,
        [Display(Name = "پاسخ داده شده")]
        Answered = 2,
        [Display(Name = "بسته شده")]
        Closed = 3
    }

    /// <summary>
    /// اولویت تیکت
    /// </summary>
    public enum TicketPriority
    {
        [Display(Name = "بحرانی")]
        Critical = 1,
        [Display(Name = "فوری")]
        Instant = 2,
        [Display(Name = "مهم")]
        Important = 3,
        [Display(Name = "عادی")]
        Normal = 4
    }

    /// <summary>
    /// نوع تیکت
    /// </summary>
    public enum TicketType
    {
        [Display(Name = "رفع مشکل")]
        Troubleshooting = 1,
        [Display(Name = "سوال")]
        Question = 2,
        [Display(Name = "پیشنهاد")]
        Proposal = 3
    }

    public enum UserType
    {
        [Display(Name = "یوزر سیستمی")]
        SystemUser = 0,
        [Display(Name = "یوزر داینامیک")]
        DynamicUser = 1,

    }

    public enum PackageType
    {
        [Display(Name = "نوع 1")]
        Type1 = 0,

    }

    public enum Permisions
    {
        Admin,
        User
    }

}
