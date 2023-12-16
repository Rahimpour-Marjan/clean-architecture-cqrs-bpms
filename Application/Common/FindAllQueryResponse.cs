using Domain.Common;
using Domain.Enums;

namespace Application.Common
{
    public class FindAllQueryResponse<TResult>
    {
        public TResult Result { get; private set; }

        public int ResultCount { get; private set; }
        public int? PageSize { get; private set; }
        public int? PageNumber { get; private set; }
        public bool Success { get; private set; }
        public string? ErrorMessage { get; private set; }
        public Exception? Exception { get; private set; }

        public static FindAllQueryResponse<TResult> BuildSuccessResult(TResult result,int resultCount,int? pageSize,int? pageNumber)
        {
            return new FindAllQueryResponse<TResult> { Success = true,Result=result, ResultCount = resultCount, PageSize = pageSize, PageNumber = pageNumber };
        }

        public static FindAllQueryResponse<TResult> BuildFailure(string errorMessage)
        {
            return new FindAllQueryResponse<TResult> { Success = false, ErrorMessage = errorMessage };
        }
        public static FindAllQueryResponse<TResult> BuildFailure(Exception ex)
        {
            return new FindAllQueryResponse<TResult> { Success = false, Exception = ex };
        }

        public static FindAllQueryResponse<TResult> BuildFailure(Exception ex, string errorMessage)
        {
            return new FindAllQueryResponse<TResult> { Success = false, Exception = ex, ErrorMessage = errorMessage };
        }

        public static FindAllQueryResponse<TResult> BuildFailure(Enum_Message message)
        {
            return new FindAllQueryResponse<TResult> { Success = false, ErrorMessage = BaseMessage.GetMessage(Enum_MessageType.ERROR,message).Body };
        }
    }
}
