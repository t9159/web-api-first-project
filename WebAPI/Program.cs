using Repositories;
using Services;
using Entities;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddTransient<IUserRepository, TxtUserRepository>();
builder.Services.AddTransient<IUserService, UsersService>();
builder.Services.AddTransient<IStrongPasswordService, StrongPasswordService>();

var app = builder.Build();

app.UseStaticFiles();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
