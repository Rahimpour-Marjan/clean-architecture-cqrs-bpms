
namespace Application.Common
{
    public class GetCurrentTastClass
    {
        public int ReturnCode { get; set; }
        public string? ReturnMessage { get; set; }
        public List<CurrentTastResult>? Result { get; set; }
        public string? ResultMessage { get; set; }
    }

    public class CurrentTastResult
    {
        public int? IdTask { get; set; }
        public string? TskName { get; set; }
    }
}
