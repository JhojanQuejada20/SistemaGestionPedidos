namespace MicroservicioDePedidos.Domain.Entities;

public enum EstadoPedido
{
    PENDIENTE,
    EN_PREPARACION,
    LISTO,
    ENTREGADO
}

public class Pedido
{
    public long Id { get; set; }
    public string Descripcion { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    public EstadoPedido Estado { get; set; } = EstadoPedido.PENDIENTE;
}
