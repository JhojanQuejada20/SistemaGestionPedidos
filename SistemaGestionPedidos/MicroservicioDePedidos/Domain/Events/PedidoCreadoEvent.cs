public class PedidoCreadoEvent
{
    public Guid PedidoId { get; }
    public List<ItemPedido> Items { get; }

    public PedidoCreadoEvent(Guid pedidoId, List<ItemPedido> items)
    {
        PedidoId = pedidoId;
        Items = items;
    }
}
