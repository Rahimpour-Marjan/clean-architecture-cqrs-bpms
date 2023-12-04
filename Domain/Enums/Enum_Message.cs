using System.ComponentModel.DataAnnotations;

namespace Domain.Enums
{
    public enum Enum_Message
    {
        NONE,

        DUPLICATED_Title,
        DUPLICATED_EnTitle,
        DUPLICATED_Code,

        TRUNCATED_Value,

        WRONG_ParentID,

        ITEMNOTFOUND,
        CANNOTDELETED,

        INVALID_UsernameAndPassword
    }

}
