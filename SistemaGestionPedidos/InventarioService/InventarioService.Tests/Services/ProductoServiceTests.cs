using Xunit;
using Moq;
using System.Threading.Tasks;
using InventarioService.Application.Services;
using InventarioService.Domain.Entities;
using InventarioService.Domain.Repositories;
using System.Collections.Generic;

public class ProductoServiceTests
{
    private readonly ProductoService _service;
    private readonly Mock<IProductoRepository> _repoMock;

    public ProductoServiceTests()
    {
        _repoMock = new Mock<IProductoRepository>();
        _service = new ProductoService(_repoMock.Object);
    }

    [Fact]
    public async Task CrearProductoAsync_DebeCrearProducto()
    {
        var producto = new Producto { Nombre = "Pan", Cantidad = 10 };
        _repoMock.Setup(r => r.CrearAsync(It.IsAny<Producto>())).ReturnsAsync(producto);

        var resultado = await _service.CrearProductoAsync("Pan", 10);

        Assert.Equal("Pan", resultado.Nombre);
        Assert.Equal(10, resultado.Cantidad);
    }

    [Fact]
    public async Task ValidarDisponibilidadAsync_DevuelveTrueSiHayStock()
    {
        var producto = new Producto { Id = 1, Nombre = "Pan", Cantidad = 20 };
        _repoMock.Setup(r => r.ValidarDisponibilidadAsync(1, 5)).ReturnsAsync(true);

        var disponible = await _service.ValidarDisponibilidadAsync(1, 5);

        Assert.True(disponible);
    }
}
