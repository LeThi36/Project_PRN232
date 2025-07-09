using LibraryWebApp.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

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
