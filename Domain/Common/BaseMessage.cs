using Domain.Enums;

namespace Domain.Common
{
    public class BaseMessage
    {
        public static ViewMessage GetMessage()
        {
            return new ViewMessage() { Type = Enum_MessageType.NONE, Body = "" };
        }


        public static ViewMessage GetMessage(Enum_MessageType type, string message)
        {
            return new ViewMessage()
            {
                Type = type,
                Body = message
            };
        }

        public static ViewMessage GetMessage(Enum_Message message)
        {
            return GetMessage(Enum_MessageType.ERROR, message);
        }

        public static ViewMessage GetMessage(Enum_MessageType type)
        {
            return new ViewMessage() { Type = type, Body = "" };
        }

        public static ViewMessage GetMessage(Enum_MessageType type, Enum_Message message)
        {
            string msg = (GetMessageString(message));
            return new ViewMessage() { Type = type, Body = msg };
        }

        private static string GetMessageString(Enum_Message message)
        {
            string msg = "";
            switch (message)
            {
                case Enum_Message.DUPLICATED_Title:
                    msg = "عنوان وارد شده تکراری می باشد!";
                    break;
                case Enum_Message.DUPLICATED_EnTitle:
                    msg = "عنوان لاتین وارد شده تکراری می باشد!";
                    break;
                case Enum_Message.DUPLICATED_Code:
                    msg = "کد وارد شده تکراری می باشد!";
                    break;
                case Enum_Message.TRUNCATED_Value:
                    msg = "مقدار وارد شده بزرگ تر از حد مجاز می باشد. نام فیلد:!";
                    break;
                case Enum_Message.WRONG_ParentID:
                    msg = "کد والد وارد شده صحیح نمی باشد!";
                    break;
                case Enum_Message.ITEMNOTFOUND:
                    msg = "آیتم مورد نظر یافت نشد!";
                    break;
                case Enum_Message.CANNOTDELETED:
                    msg = "آیتم مورد نظر به دلیل وجود آیتم های وابسته قابل حذف نمی باشد!";
                    break;
                case Enum_Message.INVALID_UsernameAndPassword:
                    msg = "نام کاربری یا کلمه عبور اشتباه می باشد!";
                    break;
                default:
                    break;
            }
            return msg;
        }
    }
}
