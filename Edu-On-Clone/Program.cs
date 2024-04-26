using Edu_On_Clone.Configurations;
using Edu_On_Clone.Middlewares;
using EduOnClone.Application.Common.Validators;
using EduOnClone.Application.Interfaces;
using EduOnClone.Application.Services;
using EduOnClone.Data.DbContexts;
using EduOnClone.Data.Interfaces;
using EduOnClone.Data.Repositories;
using EduOnClone.Domain.Entities;
using EduOnClone.Domain.Enums;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Serilog;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Cache
builder.Services.AddMemoryCache();

// Serilog
builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration));

//dbcontecxt
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDB"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

// Unit Of Work
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

// Service
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IAuthManager, AuthManager>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ISubjectService, SubjectService>();
builder.Services.AddTransient<IScienceService, ScienceService>();
builder.Services.AddTransient<IOptionService, OptionService>();
builder.Services.AddTransient<ITestService, TestService>();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddTransient<IAdminService, AdminService>();

// Configure
builder.Services.ConfigureJwtAuthorize(builder.Configuration);
builder.Services.ConfigureSwaggerAuthorize(builder.Configuration);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("SuperAdmin", policy => policy.RequireRole("SuperAdmin"));
});


//Validator
builder.Services.AddScoped<IValidator<User>, UserValidator>();
builder.Services.AddScoped<IValidator<Subject>, SubjectValidator>();
builder.Services.AddScoped<IValidator<Science>, ScienceValidator>();
builder.Services.AddScoped<IValidator<Option>, OptionValidator>();
builder.Services.AddScoped<IValidator<Test>, TestValidator>();

var app = builder.Build();


// Middlewares
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionHandleMiddleware>();

app.Run();