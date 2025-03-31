using Microsoft.AspNetCore.Mvc;
using MicroservicioDePedidos.Application.Services;
using MicroservicioDePedidos.Domain.Entities;

namespace PedidosService.Api.Controllers;

[ApiController]
[Route("api/pedidos")]
public class PedidosController : ControllerBase
{
    private readonly PedidoService _pedidoService;

    public PedidosController(PedidoService pedidoService)
    {
        _pedidoService = pedidoService;
    }

    // Crear un pedido
    [HttpPost]
    public async Task<IActionResult> CrearPedido([FromBody] string descripcion)
    {
        var pedido = await _pedidoService.CrearPedidoAsync(descripcion);
        return CreatedAtAction(nameof(ObtenerTodos), new { id = pedido.Id }, pedido);
    }

    // Obtener todos los pedidos
    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var pedidos = await _pedidoService.ObtenerTodosAsync();
        return Ok(pedidos);
    }

    // Actualizar el estado de un pedido
    [HttpPut("{id}/estado")]
    public async Task<IActionResult> ActualizarEstado(long id, [FromBody] EstadoPedido estado)
    {
        var pedido = await _pedidoService.ActualizarEstadoAsync(id, estado);
        return Ok(pedido);
    }
}
