public class ItemPedido
{
    public Guid ProductoId { get; private set; }
    public int Cantidad { get; private set; }
    public decimal PrecioUnitario { get; private set; }
    public decimal Subtotal => Cantidad * PrecioUnitario;

    public ItemPedido(Guid productoId, int cantidad, decimal precioUnitario)
    {
        ProductoId = productoId;
        Cantidad = cantidad;
        PrecioUnitario = precioUnitario;
    }
}
