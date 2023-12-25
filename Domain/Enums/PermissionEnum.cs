using System.ComponentModel;

namespace Domain.Enums
{
    public class PermissionEnum
    {
    }

    /// <summary>
    /// دسترسی های کاربر
    /// </summary>
    public enum UserPemission
    {
        [Description("بدون دسترسی")]
        NULL = 0,
        Post_View = 1,
        Post_Add = 2,
        Post_Edit = 3,
        Post_Delete = 4,
        Post_Access = 5,
        Account_View = 6,
        Account_Add = 7,
        Account_Edit = 8,
        Account_Delete = 9,
        Unit_View = 10,
        Unit_Add = 11,
        Unit_Edit = 12,
        Unit_Delete = 13,
    }

}
