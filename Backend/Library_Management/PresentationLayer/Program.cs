using DataLayer.Entities;
using DataLayer.Repositories.Abstraction;
using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using BussinessLayer.Services.Interface;
using BussinessLayer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProjectPrn232Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IRevokedTokenService, RevokedTokenService>();
builder.Services.AddScoped<IUserService, UserService>();

// Cấu hình xác thực JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };

        // Thêm kiểm tra custom để vô hiệu hóa token (blacklist)
        options.Events = new JwtBearerEvents
        {
            OnTokenValidated = async context =>
            {
                var token = context.SecurityToken as JwtSecurityToken;
                if (token == null)
                {
                    context.Fail("Token không hợp lệ.");
                    return;
                }

                var tokenString = token.RawData; // Lấy chuỗi token gốc

                // Lấy dịch vụ IRevokedTokenService từ service provider
                var revokedTokenService = context.HttpContext.RequestServices.GetRequiredService<IRevokedTokenService>();

                // Kiểm tra xem token có bị thu hồi không
                if (await revokedTokenService.IsTokenRevokedAsync(tokenString))
                {
                    context.Fail("Token đã bị vô hiệu hóa."); // Vô hiệu hóa ngữ cảnh xác thực
                }
            }
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
