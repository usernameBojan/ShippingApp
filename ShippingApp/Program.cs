using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShippingApp.Application.Mapper;
using ShippingApp.Application.Repository;
using ShippingApp.Application.Services;
using ShippingApp.Application.Services.Implementation;
using ShippingApp.Application.Utilities;
using ShippingApp.Domain.Entities;
using ShippingApp.Infrastructure;
using ShippingApp.Infrastructure.Repositories;
using System.Security.Claims;
using System.Text;

const string corsPolicy = "CorsPolicy";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IParcelService, ParcelService>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<IRepository<Admin>, BaseRepository<Admin>>();
builder.Services.AddScoped<IRepository<Company>, BaseRepository<Company>>();
builder.Services.AddScoped<IRepository<ParcelInquiryStatistics>, BaseRepository<ParcelInquiryStatistics>>();
builder.Services.AddScoped<IRepository<Order>, BaseRepository<Order>>();

builder.Services.AddSingleton(sp => EntitiesMapper.GetConfiguration());
builder.Services.AddScoped(sp => sp.GetRequiredService<MapperConfiguration>().CreateMapper());

builder.Services.AddDbContext<ApplicationDbContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opts =>
{
    opts.TokenValidationParameters = new()
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddAuthorization(opts =>
{
    opts.AddPolicy(Policies.MustHaveId, builder => builder.RequireClaim(ClaimTypes.NameIdentifier));
});

builder.Services.AddCors(opts =>
{
    opts.AddPolicy(corsPolicy, policyBuilder => policyBuilder.WithOrigins("http://localhost:4200")
                                                             .AllowAnyHeader()
                                                             .AllowAnyMethod()
                                                             .AllowCredentials());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(corsPolicy);

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();