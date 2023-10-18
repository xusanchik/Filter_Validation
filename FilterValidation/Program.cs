using FilterValidation.Data;
using FilterValidation.Dto_s;
using FilterValidation.Entities;
using FilterValidation.FluentValidation;
using FilterValidation.Interfaca;
using FilterValidation.Repasitory;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading.RateLimiting;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepaasitory, UserRepasitory>();
builder.Services.AddScoped<IValidator<UserDto>, UserValidation>();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
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
