using Domain.Enums;

namespace Domain.Common
{
    public class ViewMessage
    {
        public Enum_MessageType Type { get; set; }
        public string Body { get; set; }

        public ViewMessage()
        {
            this.Type = Enum_MessageType.SUCCESS;
        }
    }
}
