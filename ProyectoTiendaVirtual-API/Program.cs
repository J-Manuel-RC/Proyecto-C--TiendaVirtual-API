using Microsoft.EntityFrameworkCore;
using ProyectoTiendaVirtual_API.Models;
//using ProyectoTiendaVirtual_API.Models;

var builder = WebApplication.CreateBuilder(args);

string cadena = builder.Configuration.GetConnectionString("conexion");

builder.Services.AddDbContext<tiendavirtualContext>(
    obj => obj.UseSqlServer(cadena));


// Add services to the container.

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
