using Microsoft.EntityFrameworkCore;
using InventarioService.Domain.Entities;

namespace InventarioService.Infrastructure.Persistence
{
    public class InventarioDbContext : DbContext
    {
        public InventarioDbContext(DbContextOptions<InventarioDbContext> options) : base(options) { }
        public DbSet<Producto> Productos { get; set; }
    }
}
