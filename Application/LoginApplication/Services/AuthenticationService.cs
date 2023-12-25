using Application.LoginApplication.Commands;
using Application.LoginApplication.Interfaces;
using Application.LoginApplication.Options;
using Application.User.Queries.FindByAuthInfo;
using Application.Users.Models;
using CryptoHashVerify;
using Domain.Common;
using Domain.Enums;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.LoginApplication.Services
{
    public class AuthenticationService : IAuthentication
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IMediator _mediator;
        public AuthenticationService(IMediator mediator/*,JwtSettings jwtSettings*/)
        {
            _mediator = mediator;
            _jwtSettings = new JwtSettings()
            {
                Secret = "il@v&ch@nDuil@v&ch@nDuil@v&ch@nDu",
                TokenLifetime = TimeSpan.Parse("02:00:00")
            };
            //_jwtSettings = jwtSettings;
        }

        public async Task<Login.Response> LoginAsync(Login.Command request)
        {
            var response = new Login.Response();
            var userInfo = await _mediator.Send(new FindUserByUserNameQuery()
            {
                UserName = request.UserName,
            });
            if (userInfo == null)
            {
                response = new Login.Response
                {
                    Errors = new[] { BaseMessage.GetMessage(Enum_MessageType.ERROR, Enum_Message.INVALID_UsernameAndPassword).Body }
                };
            }
            else
            {
                var hashedPassword = userInfo.Password;
                var salt = userInfo.Salt;
                var clearPassword = request.Password;

                if (CheckPasswordAsync(hashedPassword, salt, clearPassword))
                {
                    response = await GenerateAuthenticationResponseForUserAsync(userInfo);

                }
                else
                {
                    response = new Login.Response
                    {
                        Errors = new[] { BaseMessage.GetMessage(Enum_MessageType.ERROR, Enum_Message.INVALID_UsernameAndPassword).Body }
                    };
                }
            }

            return response;
        }

        private bool CheckPasswordAsync(string hashedPassword, string salt, string clearPassword)
        {
            return HashVerify.VerifyHashString(hashedPassword, salt, clearPassword);
        }

        private Task<Login.Response> GenerateAuthenticationResponseForUserAsync(UserInfo user)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var claims = new List<Claim>
            {
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
               new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
               new Claim("Id", user.Id.ToString()),
               new Claim("UserName", user.UserName),
               //new Claim("Password", user.Password),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Audience = "http://com",
                Expires = DateTime.UtcNow.Add(_jwtSettings.TokenLifetime),
                SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };


            var token = jwtHandler.CreateToken(tokenDescriptor);

            return Task.FromResult(new Login.Response
            {
                IsSuccess = true,
                Token = jwtHandler.WriteToken(token)
            });
        }

        public (string, string) GenerateHashPasswordAndSalt(string password)
        {
            return HashVerify.GenerateHashString(password);
        }
    }
}
