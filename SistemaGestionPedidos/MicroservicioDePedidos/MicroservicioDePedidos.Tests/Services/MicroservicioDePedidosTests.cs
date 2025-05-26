using Xunit;
using MicroservicioDePedidos.Application.Services;
using MicroservicioDePedidos.Domain.Entities;
using MicroservicioDePedidos.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class PedidoServiceTests
{
    private PedidoService _service;
    private PedidoDbContext _context;

    public PedidoServiceTests()
    {
        var options = new DbContextOptionsBuilder<PedidoDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        _context = new PedidoDbContext(options);
        var repo = new PedidoRepository(_context);
        _service = new PedidoService(repo);
    }

    [Fact]
    public async Task CrearPedidoAsync_CreaUnPedido_Exitosamente()
    {
        var pedido = await _service.CrearPedidoAsync("Cliente 1", 1, 5);

        Assert.NotNull(pedido);
        Assert.Equal("Cliente 1", pedido.Cliente);
        Assert.Equal(1, pedido.ProductoId);
        Assert.Equal(5, pedido.Cantidad);
    }
}
