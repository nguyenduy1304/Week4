using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.Interfaces;
using WebAPI.Application.Services;
using WebAPI.Application.Validations;
using WebAPI.Contract.Requests;
using WebAPI.Persistence.DataContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddValidatorsFromAssemblyContaining<WebAPI.Application.Validations.UserValidation>();

builder.Services.AddScoped<IUserSevice, UserService>();
builder.Services.AddScoped<IValidator<CreateUserRequest>, UserValidation>();


builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
