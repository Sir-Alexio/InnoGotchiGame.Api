using AutoMapper;
using InnoGotchi_backend.DataContext;
using InnoGotchi_backend.Mapping;
using InnoGotchi_backend.Models;
using InnoGotchi_backend.Models.Dto;
using InnoGotchi_backend.Repositories;
using InnoGotchi_backend.Repositories.Abstract;
using InnoGotchi_backend.Services.Abstract;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Text;
using InnoGotchi_backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "Standart Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
var config = new MapperConfiguration(cfg =>
{
    // Create a mapping from User to UserDto
    cfg.CreateMap<User, UserDto>();
});
builder.Services.AddAutoMapper(typeof(MappingProfile));

//builder.Services.AddAuthentication(
//    JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => 
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
//            builder.Configuration.GetSection("AppSettings:Token").Value)),
//        ValidateIssuer = false,
//        ValidateAudience = false
//    });

//JWT from book
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = Environment.GetEnvironmentVariable("SECRET");

builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
 .AddJwtBearer(options =>
 {
     options.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuer = true,
         ValidateAudience = true,
         ValidateLifetime = true,
         ValidateIssuerSigningKey = true,
         ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
         ValidAudience = jwtSettings.GetSection("validAudience").Value,
         IssuerSigningKey = new
    SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
     };
 });
//end of JWT
//Delete
builder.Services.AddAuthentication().AddCookie("Cookies");

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
