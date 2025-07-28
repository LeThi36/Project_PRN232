using BussinessLayer.Services.Interface;
using BussinessLayer.Services;
using LibraryWebApp.Handlers;
using DataLayer.Repositories.Abstraction;
using DataLayer.Repositories;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IPublisherService, PublisherService>();
builder.Services.AddDbContext<ProjectPrn232Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Đăng ký IHttpContextAccessor để có thể truy cập HttpContext trong các service
builder.Services.AddHttpContextAccessor();

// Đăng ký DelegatingHandler
builder.Services.AddTransient<AuthHeaderHandler>();

// Configure HttpClient
builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"] ?? "https://localhost:7092");
})
    .AddHttpMessageHandler<AuthHeaderHandler>(); // Thêm handler vào pipeline

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
