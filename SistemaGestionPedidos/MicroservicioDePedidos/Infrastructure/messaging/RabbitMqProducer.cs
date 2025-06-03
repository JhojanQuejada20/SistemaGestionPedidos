using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace PedidosService.Infrastructure.Messaging
{
    public class RabbitMqProducer
    {
        private readonly string _hostname = "localhost";
        private readonly string _queueName = "pedido-creado";
        private IConnection _connection;

        public RabbitMqProducer()
        {
            var factory = new ConnectionFactory() { HostName = _hostname };
            _connection = factory.CreateConnection();
        }

        public void EnviarMensaje(object mensaje)
        {
            using var canal = _connection.CreateModel();
            canal.QueueDeclare(queue: _queueName,
                               durable: false,
                               exclusive: false,
                               autoDelete: false,
                               arguments: null);

            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(mensaje));

            canal.BasicPublish(exchange: "",
                               routingKey: _queueName,
                               basicProperties: null,
                               body: body);
        }
    }
}
