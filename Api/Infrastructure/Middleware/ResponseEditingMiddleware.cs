namespace Api.Infrastructure.Middleware
{
    public class ResponseEditingMiddleware
    {
        private readonly RequestDelegate _next;
        public ResponseEditingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            //if (context.Response.StatusCode == 400)
            //{
            //    await context.Response.WriteAsync("400 - Bad Request");
            //}
            //if (context.Response.StatusCode == 404)
            //{
            //    await context.Response.WriteAsync("404 - Resource not found");
            //}
            //else if (context.Response.StatusCode == 401)
            //{
            //    await context.Response.WriteAsync("401 - Invalid credentials");
            //}
            //else if (context.Response.StatusCode == 403)
            //{
            //    await context.Response.WriteAsync("403 - Forbidden");
            //}

            //var result = JsonConvert.SerializeObject(errorMessage);

            //return context.Response.WriteAsync(result);
        }
    }
}
