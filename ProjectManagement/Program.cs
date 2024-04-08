using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using ProjectManagement;
using ProjectManagement.DbContexts;
using ProjectManagement.ManagerInterfaces;
using ProjectManagement.Managers;

var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = Env.GetString("DB_CONNECTION_STRING");

builder.Services.AddControllers();

builder.Services.AddDbContext<ProjectManagementDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<IProjectManager, ProjectManager>();
builder.Services.AddScoped<ITaskManager, TaskManager>();
builder.Services.AddScoped<IStatusManager, StatusManager>();

builder.Services.AddCors(options => options.AddPolicy("cors" ,builder =>
{
    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCors("cors");

app.MapControllers();

app.Run();
