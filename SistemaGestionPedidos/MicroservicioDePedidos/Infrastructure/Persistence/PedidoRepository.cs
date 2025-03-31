using Microsoft.EntityFrameworkCore;
using MicroservicioDePedidos.Domain.Entities;
using MicroservicioDePedidos.Domain.Repositories;

namespace PedidosService.Infrastructure.Persistence;

public class PedidosDbContext : DbContext
{
    public PedidosDbContext(DbContextOptions<PedidosDbContext> options) : base(options) { }
    public DbSet<Pedido> Pedidos { get; set; }
}

public class PedidoRepository : IPedidoRepository
{
    private readonly PedidosDbContext _context;

    public PedidoRepository(PedidosDbContext context)
    {
        _context = context;
    }

    public async Task<Pedido> CrearPedidoAsync(Pedido pedido)
    {
        _context.Pedidos.Add(pedido);
        await _context.SaveChangesAsync();
        return pedido;
    }

    public async Task<List<Pedido>> ObtenerTodosAsync()
    {
        return await _context.Pedidos.ToListAsync();
    }

    public async Task<Pedido> ObtenerPorIdAsync(long id)
    {
        return await _context.Pedidos.FindAsync(id);
    }

    public async Task<Pedido> ActualizarPedidoAsync(Pedido pedido)
    {
        _context.Pedidos.Update(pedido);
        await _context.SaveChangesAsync();
        return pedido;
    }
}
