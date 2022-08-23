using CpmPedido.Api;
using CpmPedido.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var dbConnection = new NpgsqlConnection(builder.Configuration.GetConnectionString("ConnectionString"));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(
        dbConnection,
        assembly => assembly.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
});

DependencyInjector.Register(builder.Services);

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
