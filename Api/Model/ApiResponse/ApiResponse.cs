namespace Api
{
    public class ApiResponse
    {
        public ApiResponse()
        {
        }
        public ApiResponse(object data, string[] errors)
        {
            Errors = errors;
            Data = data;
        }
        public object Data { get; set; }
        public string[] Errors { get; set; }
    }
}
