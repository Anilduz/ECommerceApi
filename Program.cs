// Program.cs
using ECommerceApi.Repositories;
using ECommerceApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// DI - Repository'ler
builder.Services.AddSingleton<IProductRepository, InMemoryProductRepository>();
builder.Services.AddSingleton<IUserRepository, InMemoryUserRepository>();
builder.Services.AddSingleton<IOrderRepository, InMemoryOrderRepository>();

// DI - Servisler (Ýþ Mantýðý)
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

// Global Exception Middleware'i HTTP pipeline'ýnýn en baþýna ekleme
app.UseGlobalExceptionMiddleware();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();