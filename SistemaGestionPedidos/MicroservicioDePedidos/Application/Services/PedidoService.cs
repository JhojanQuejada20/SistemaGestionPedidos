using MicroservicioDePedidos.Domain.Entities;
using MicroservicioDePedidos.Domain.Repositories;

namespace MicroservicioDePedidos.Application.Services;

public class PedidoService
{
    private readonly IPedidoRepository _pedidoRepository;

    public PedidoService(IPedidoRepository pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }

    public async Task<Pedido> CrearPedidoAsync(string descripcion)
    {
        var pedido = new Pedido { Descripcion = descripcion };
        return await _pedidoRepository.CrearPedidoAsync(pedido);
    }

    public async Task<List<Pedido>> ObtenerTodosAsync()
    {
        return await _pedidoRepository.ObtenerTodosAsync();
    }

    public async Task<Pedido> ActualizarEstadoAsync(long id, EstadoPedido estado)
    {
        var pedido = await _pedidoRepository.ObtenerPorIdAsync(id);
        if (pedido == null) throw new Exception("Pedido no encontrado");
        
        pedido.Estado = estado;
        return await _pedidoRepository.ActualizarPedidoAsync(pedido);
    }
}
