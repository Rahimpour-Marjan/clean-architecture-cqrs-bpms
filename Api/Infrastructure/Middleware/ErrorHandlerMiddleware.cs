using Domain.Common;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Net;

namespace Api.Infrastructure.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;
        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                if (context.Response.HasStarted)
                {
                    _logger.LogWarning("The response has already started, the Exception Middleware will not be executed");
                    throw;
                }
                await HandleExceptionAsync(context, ex);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var statusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            //var message = ex.Message;
            var message = "خطای سرور!";

            if (ex.InnerException != null)
            {
                var innerExceptionMsg = ex.InnerException.Message;
                var exceptionNumber = ((SqlException)ex.InnerException).Number;
                switch (exceptionNumber)
                {
                    case 2601:
                        if (ex.InnerException.Message.Contains("_Title"))
                            message = BaseMessage.GetMessage(Enum_MessageType.ERROR, Enum_Message.DUPLICATED_Title).Body;
                        if (ex.InnerException.Message.Contains("_EnTitle"))
                            message = BaseMessage.GetMessage(Enum_MessageType.ERROR, Enum_Message.DUPLICATED_EnTitle).Body;
                        if (ex.InnerException.Message.Contains("_Code"))
                            message = BaseMessage.GetMessage(Enum_MessageType.ERROR, Enum_Message.DUPLICATED_Code).Body;
                        break;
                    case 2628:
                        var column = innerExceptionMsg.Substring(innerExceptionMsg.IndexOf("column '") + 8, innerExceptionMsg.IndexOf("'", innerExceptionMsg.IndexOf("column '") + 9) - innerExceptionMsg.IndexOf("column '") - 8);
                        message = BaseMessage.GetMessage(Enum_MessageType.ERROR, Enum_Message.TRUNCATED_Value).Body + " " + column;
                        break;
                    case 547:
                        if (ex.InnerException.Message.Contains("DELETE"))
                            message = BaseMessage.GetMessage(Enum_MessageType.ERROR, Enum_Message.CANNOTDELETED).Body;
                        break;
                    //default:
                    //    message = innerExceptionMsg;
                    //    break;
                }
            }
            else if (ex.Message.Contains("Authentication"))
            {
                message = "شما مجوز دسترسی به این صفحه را ندارید.";
            }

            var errorMessage = new
            {
                data = (object)null,
                errors = new[] { message }
            };

            var result = JsonConvert.SerializeObject(errorMessage);

            return context.Response.WriteAsync(result);
        }
    }
}
