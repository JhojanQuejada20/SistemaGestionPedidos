using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using InventarioService.Infrastructure.Persistence;
using InventarioService.Domain.Repositories;
using InventarioService.Application.Services;




var builder = WebApplication.CreateBuilder(args);

// Configurar PostgreSQL
builder.Services.AddDbContext<InventarioDbContext>(options =>
    options.UseNpgsql("Host=localhost;Database=inventariodb;Username=postgres;Password=proyectos2025*"));

// Inyección de dependencias
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<ProductoService>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
