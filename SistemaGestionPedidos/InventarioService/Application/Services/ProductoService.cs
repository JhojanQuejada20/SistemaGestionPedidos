using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InventarioService.Domain.Entities;
using InventarioService.Domain.Repositories;

namespace InventarioService.Application.Services
{
    public class ProductoService
    {
        private readonly IProductoRepository _repo;

        public ProductoService(IProductoRepository repo)
        {
            _repo = repo;
        }

        public async Task<Producto> CrearProductoAsync(string nombre, int cantidad)
        {
            var producto = new Producto { Nombre = nombre, Cantidad = cantidad };
            return await _repo.CrearAsync(producto);
        }

        public async Task<List<Producto>> ObtenerTodosAsync() => await _repo.ObtenerTodosAsync();

        public async Task<Producto> ObtenerPorIdAsync(long id) => await _repo.ObtenerPorIdAsync(id);

        public async Task<bool> ValidarDisponibilidadAsync(long id, int cantidad)
        {
            return await _repo.ValidarDisponibilidadAsync(id, cantidad);
        }

        public async Task<Producto> ActualizarCantidadAsync(long id, int cantidad)
        {
            var producto = await _repo.ObtenerPorIdAsync(id);
            if (producto == null) throw new Exception("Producto no encontrado");

            producto.Cantidad = cantidad;
            return await _repo.ActualizarAsync(producto);
        }

        public async Task ManejarEventoPedidoCreado(long productoId, int cantidad)
        {
            var producto = await _repo.ObtenerPorIdAsync(productoId);
            if (producto == null || producto.Cantidad < cantidad) return;
            producto.Cantidad -= cantidad;
            await _repo.ActualizarAsync(producto);
        }
    }
}
