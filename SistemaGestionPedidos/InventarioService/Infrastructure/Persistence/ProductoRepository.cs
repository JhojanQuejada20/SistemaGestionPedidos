using InventarioService.Domain.Entities;
using InventarioService.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventarioService.Infrastructure.Persistence
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly InventarioDbContext _context;

        public ProductoRepository(InventarioDbContext context)
        {
            _context = context;
        }

        public async Task<Producto> CrearAsync(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task<List<Producto>> ObtenerTodosAsync()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<Producto> ObtenerPorIdAsync(long id)
        {
            return await _context.Productos.FindAsync(id);
        }

        public async Task<Producto> ActualizarAsync(Producto producto)
        {
            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task<bool> ValidarDisponibilidadAsync(long id, int cantidad)
        {
            var producto = await _context.Productos.FindAsync(id);
            return producto != null && producto.Cantidad >= cantidad;
        }
    }
}
