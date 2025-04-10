using System.Collections.Generic;
using System.Threading.Tasks;
using InventarioService.Domain.Entities;

namespace InventarioService.Domain.Repositories
{
    public interface IProductoRepository
    {
        Task<Producto> CrearAsync(Producto producto);
        Task<List<Producto>> ObtenerTodosAsync();
        Task<Producto> ObtenerPorIdAsync(long id);
        Task<Producto> ActualizarAsync(Producto producto);
        Task<bool> ValidarDisponibilidadAsync(long id, int cantidad);
    }
}
