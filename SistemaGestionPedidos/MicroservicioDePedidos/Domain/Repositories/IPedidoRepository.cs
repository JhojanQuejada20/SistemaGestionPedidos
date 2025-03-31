using MicroservicioDePedidos.Domain.Entities;

namespace MicroservicioDePedidos.Domain.Repositories;

public interface IPedidoRepository
{
    Task<Pedido> CrearPedidoAsync(Pedido pedido);
    Task<List<Pedido>> ObtenerTodosAsync();
    Task<Pedido> ObtenerPorIdAsync(long id);
    Task<Pedido> ActualizarPedidoAsync(Pedido pedido);
}
