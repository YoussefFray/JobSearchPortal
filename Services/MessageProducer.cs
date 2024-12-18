using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace JobSearchPortal.Services
{
    public class MessageProducer : IMessageProducer
    {
        public async void SendingMessage<T>(T message)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "user",
                Password = "mypassword",
                VirtualHost = "/"
            };
            var connection = await factory.CreateConnectionAsync();

            using var channel = await connection.CreateChannelAsync();
            channel.QueueDeclareAsync("notifications", durable: false, exclusive: false, autoDelete: false, arguments: null);

            var jsonString = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(jsonString);
             channel.BasicPublishAsync("", "notifications", body: body);
        }
    }
}
