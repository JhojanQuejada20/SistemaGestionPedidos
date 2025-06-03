public class PedidoService
{
    private readonly IPedidoRepository _repository;
    private readonly IMessagePublisher _publisher;

    public PedidoService(IPedidoRepository repository, IMessagePublisher publisher)
    {
        _repository = repository;
        _publisher = publisher;
    }

    public async Task<Guid> CrearPedidoAsync(CrearPedidoCommand command)
    {
        var items = command.Items.Select(i => new ItemPedido(i.ProductoId, i.Cantidad, i.Precio)).ToList();
        var pedido = new Pedido(command.ClienteId, items);

        await _repository.AddAsync(pedido);

        var evento = new PedidoCreadoEvent(pedido.Id, pedido.Items);
        await _publisher.PublicarAsync(evento);

        return pedido.Id;
    }
}
