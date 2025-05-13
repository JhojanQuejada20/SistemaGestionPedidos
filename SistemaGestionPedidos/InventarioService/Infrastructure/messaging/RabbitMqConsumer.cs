using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace InventarioService.Infrastructure.Messaging
{
    public class RabbitMqConsumer
    {
        private readonly string _hostname = "localhost";
        private readonly string _queueName = "pedido-creado";
        private readonly IServiceScopeFactory _scopeFactory;

        public RabbitMqConsumer(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public void Iniciar()
        {
            var factory = new ConnectionFactory() { HostName = _hostname };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare(queue: _queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var mensajeJson = Encoding.UTF8.GetString(body);

                var datos = JsonSerializer.Deserialize<PedidoCreadoEvent>(mensajeJson);

                using var scope = _scopeFactory.CreateScope();
                var servicio = scope.ServiceProvider.GetRequiredService<ProductoService>();
                await servicio.ManejarEventoPedidoCreado(datos.ProductoId, datos.Cantidad);
            };

            channel.BasicConsume(queue: _queueName,
                                 autoAck: true,
                                 consumer: consumer);
        }

        private class PedidoCreadoEvent
        {
            public long ProductoId { get; set; }
            public int Cantidad { get; set; }
        }
    }
}