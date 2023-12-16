using Application.LoginApplication.Interfaces;
using System;

namespace Application.LoginApplication.Options
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public TimeSpan TokenLifetime { get; set; }
    }
}
