using Application.LoginApplication.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Api.Infrastructure.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JwtSettings _jwtSettings;
        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
            _jwtSettings = new JwtSettings()
            {
                Secret = "il@v&ch@nDuil@v&ch@nDuil@v&ch@nDu",
                TokenLifetime = TimeSpan.Parse("24:00:00")
            };
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var jwtTokenKey = context.Request
                               .Headers["Authorization"]
                               .FirstOrDefault()?
                               .Split(" ")
                               .Last();

            var userId = 0;
            if (jwtTokenKey is not null)
            {
                try
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
                    tokenHandler.ValidateToken(jwtTokenKey, new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    }, out SecurityToken validatedToken);

                    var jwtToken = (JwtSecurityToken)validatedToken;
                    userId = int.Parse(jwtToken.Claims.First(x => x.Type == "Id").Value);
                }
                catch
                {
                    // log error ......
                }
            }
            context.Items.Add("UserId", userId);

            await _next(context);
        }
    }
}