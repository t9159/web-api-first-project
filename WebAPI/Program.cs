using Repositories;
using Services;
using Entities;
using Microsoft.EntityFrameworkCore;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Host.UseNLog();
builder.Services.AddControllers();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UsersService>();
builder.Services.AddTransient<IStrongPasswordService, StrongPasswordService>();
builder.Services.AddTransient<IProductsService, ProductsService>();
builder.Services.AddTransient<IProductsRepository, ProductRepository>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<StoreDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Home")), ServiceLifetime.Transient);
var app = builder.Build();


app.UseStaticFiles();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
