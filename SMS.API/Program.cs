using Microsoft.EntityFrameworkCore;
using SMS.Domain.Interfaces;
using SMS.Infrastructure;
using SMS.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ICountry, CountryRepository>();
builder.Services.AddScoped<IState, StateRepository>();
builder.Services.AddScoped<IDistrict, DistrictRepository>();
builder.Services.AddScoped<IUser, UserRepository>();
builder.Services.AddScoped<IRole, RoleRepository>();
builder.Services.AddScoped<IUserRole, UserRoleRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
