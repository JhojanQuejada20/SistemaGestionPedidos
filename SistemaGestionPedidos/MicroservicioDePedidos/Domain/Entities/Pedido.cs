public class Pedido
{
    public Guid Id { get; private set; }
    public Guid ClienteId { get; private set; }
    public DateTime Fecha { get; private set; }
    public List<ItemPedido> Items { get; private set; }
    public decimal Total { get; private set; }

    public Pedido(Guid clienteId, List<ItemPedido> items)
    {
        Id = Guid.NewGuid();
        ClienteId = clienteId;
        Fecha = DateTime.UtcNow;
        Items = items;
        Total = items.Sum(i => i.Subtotal);
    }
}
