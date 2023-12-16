using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Api.Infrastructure.Services.Contracts;

namespace Api.Infrastructure.Services
{
    public class AnonymousRequestCheckService : IAnonymousRequestCheckService
    {
        private readonly IConfiguration _configuration;

        public AnonymousRequestCheckService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Validate(HttpContext context)
        {
            var methodCompare = 0;
            var urlCompare = 0;
            for (int i = 1; i < 7; i++)
            {
                var url = _configuration.GetValue<string>("AnonymousUri" + i + ":Url");
                var method =
                    _configuration.GetValue<string>("AnonymousUri" + i + ":Method");

                methodCompare =
                   string.Compare(method, context.Request.Method, StringComparison.OrdinalIgnoreCase);

                urlCompare =
                    string.Compare(url, context.Request.Path, StringComparison.OrdinalIgnoreCase);

                if (methodCompare == 0 && urlCompare == 0)
                    return true;
            }
            return false;
        }
    }
}