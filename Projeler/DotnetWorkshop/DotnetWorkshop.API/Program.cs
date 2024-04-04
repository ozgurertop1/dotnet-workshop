﻿using Autofac.Extensions.DependencyInjection;
using DotnetWorkshop.Core.Repositories;
using DotnetWorkshop.Core.Services;
using DotnetWorkshop.Core.UnitofWorks;
using DotnetWorkshop.Repository;
using DotnetWorkshop.Repository.Repositories;
using DotnetWorkshop.Repository.UnitOfWorks;
using DotnetWorkshop.Service.Authorization.Abstract;
using DotnetWorkshop.Service.Authorization.Concrete;
using DotnetWorkshop.Service.Mapping;
using DotnetWorkshop.Service.Services;
using DotnetWorkshop.Service.Validations;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Swagger İşlemleri
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});

#endregion

//automapper kütüphanesi tanımlanması
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IJwtAuthenticationManager, JwtAuthenticationManager>();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));

//FluentValidation tanımalamsı gerçekleştirilmesi
//1.Yöntem
//builder.Services.AddControllers()
//    .AddFluentValidation(x =>
//    {
//        x.RegisterValidatorsFromAssemblyContaining<TeamDtoValidator>();
//        x.RegisterValidatorsFromAssemblyContaining<UserDtoValidator>();
//        x.RegisterValidatorsFromAssemblyContaining<UserProfileDtoValidator>();
//    });

//2.Yöntem
builder.Services.AddControllers().AddFluentValidation(x =>
{
    x.RegisterValidatorsFromAssemblyContaining<TeamDtoValidator>();
});


//AppDbContext işlemler
builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});

//Autofac kütüphanesini ekledik. Bu kütüphane amacıyla (generic repository vb) işlemler
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

//Buranın devamı Apı katmanında

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
