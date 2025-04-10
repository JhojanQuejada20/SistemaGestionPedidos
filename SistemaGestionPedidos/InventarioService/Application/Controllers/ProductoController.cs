using Microsoft.AspNetCore.Mvc;
using InventarioService.Application.Services;
using InventarioService.Domain.Entities;
using System.Threading.Tasks;

namespace InventarioService.Application.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoService _service;

        public ProductoController(ProductoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Producto producto)
        {
            var creado = await _service.CrearProductoAsync(producto.Nombre, producto.Cantidad);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = creado.Id }, creado);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos() => Ok(await _service.ObtenerTodosAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(long id)
        {
            var producto = await _service.ObtenerPorIdAsync(id);
            return producto == null ? NotFound() : Ok(producto);
        }

        [HttpGet("{id}/disponibilidad/{cantidad}")]
        public async Task<IActionResult> ValidarDisponibilidad(long id, int cantidad)
        {
            var disponible = await _service.ValidarDisponibilidadAsync(id, cantidad);
            return Ok(new { Disponible = disponible });
        }

        [HttpPut("{id}/cantidad")]
        public async Task<IActionResult> ActualizarCantidad(long id, [FromBody] int cantidad)
        {
            var actualizado = await _service.ActualizarCantidadAsync(id, cantidad);
            return Ok(actualizado);
        }
    }
}
