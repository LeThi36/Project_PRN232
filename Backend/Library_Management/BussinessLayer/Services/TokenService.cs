using BussinessLayer.Services.Interface;
using DataLayer.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;

        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateAccessToken(User user)
        {
            var claims = new[]
            {
                // Sử dụng ClaimTypes.NameIdentifier cho một ID người dùng duy nhất, hoặc một chuỗi tùy chỉnh cho "StudentCode"
                new Claim(ClaimTypes.NameIdentifier, user.StudentCode), // Hoặc "studentCode", hoặc "sub"
                new Claim(ClaimTypes.Role, user.RoleId) // Đúng cho vai trò
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(15), // Xem xét việc đặt thời gian này có thể cấu hình được
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
