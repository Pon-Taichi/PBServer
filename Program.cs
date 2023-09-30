using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PBServer.Context;
using PBServer.Controllers;
using PBServer.Repositories;
using PBServer.Services;
using PBServer.Services.Interfaces;
using PBServer.Utils;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var firebase = builder.Configuration.GetSection("Firebase")
            ?? throw new Exception("Firebaseの設定に不備があります");

        options.Authority = firebase.GetSection("Url").Value;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = firebase.GetSection("Url").Value,
            ValidateAudience = true,
            ValidAudience = firebase.GetSection("ProjectId").Value,
            ValidateLifetime = true
        };
    });

builder.Services.AddDbContext<PbContext>((options) =>
    options.UseNpgsql(connectionString)
);

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IContextProvider, ContextProvider>();

builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectUserRepository, ProjectUserRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

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

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();
