using Microsoft.EntityFrameworkCore;
using PBServer.Controllers;
using PBServer.Repositories;
using PBServer.Services;
using PBServer.Services.Interfaces;
using PBServer.Utils;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<PbContext>((options) =>
    options.UseNpgsql(connectionString)
);

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

app.UseAuthorization();

app.MapControllers();

app.Run();
