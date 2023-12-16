
namespace Application.Common
{
    public class GetUserReturnClass
    {
        public int ReturnCode { get; set; }
        public string ReturnMessage { get; set; }
        public List<UserInfoReturnClass> Result { get; set; }
        public string ResultMessage { get; set; }
    }
}
