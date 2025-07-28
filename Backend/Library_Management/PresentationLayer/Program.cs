using DataLayer.Entities;
using DataLayer.Repositories.Abstraction;
using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using BussinessLayer.Services.Interface;
using BussinessLayer.Services;
using BussinessLayer.Mappings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BussinessLayer.Helper.FileService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Đăng ký DbContext
builder.Services.AddDbContext<ProjectPrn232Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Cấu hình Dependency Injection
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IPaginationRepository<>), typeof(PaginationRepository<>));

builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IRevokedTokenService, RevokedTokenService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBorrowOrderService, BorrowOrderService>();
builder.Services.AddScoped<IBookFavoriteService, BookFavoriteService>();
builder.Services.AddScoped<IPublisherService, PublisherService>();
builder.Services.AddScoped<IBookCopyService, BookCopyService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>();

builder.Services.AddScoped<IFileService, FileService>();


// Đăng ký AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// ✅ Cấu hình CORS cho phép frontend gọi API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("https://localhost:7007") // Port frontend
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Cấu hình xác thực JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            SaveSigninToken = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };

        // Thêm kiểm tra token bị thu hồi
        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context => // Thêm event này để bắt lỗi chi tiết hơn
            {
                var logger = context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger(nameof(JwtBearerEvents));
                logger.LogError("Authentication failed: {0}", context.Exception.Message);
                return Task.CompletedTask;
            },
            OnTokenValidated = async context =>
            {
                // Lấy raw token từ header
                var auth = context.Request.Headers["Authorization"].ToString();
                if (!auth.StartsWith("Bearer "))
                {
                    context.Fail("Token không hợp lệ.");
                    return;
                }
                var tokenString = auth.Substring("Bearer ".Length).Trim();

                // Lấy IRevokedTokenService từ DI container
                var revokedTokenService = context.HttpContext.RequestServices
                    .GetRequiredService<IRevokedTokenService>();

                // Kiểm tra token có bị thu hồi không
                if (await revokedTokenService.IsTokenRevokedAsync(tokenString))
                {
                    context.Fail("Token đã bị vô hiệu hóa.");
                }
            }
        };
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("https://localhost:7007")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
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
app.UseStaticFiles();

// ✅ Áp dụng CORS ở đây (trước Authentication)
app.UseCors("AllowFrontend");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
