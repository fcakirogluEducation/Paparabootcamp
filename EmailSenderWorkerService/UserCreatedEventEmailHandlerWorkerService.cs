using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System.Threading.Channels;
using RabbitMQ.Client.Events;
using TokenAuth.Service.Events;

namespace EmailSenderWorkerService
{
    public class UserCreatedEventEmailHandlerWorkerService(IConfiguration configuration) : BackgroundService
    {
        private IModel channel;
        private const string QueueName = "user.created.event.queue";

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            var connectionFactory = new ConnectionFactory
            {
                Uri = new Uri(configuration.GetSection("ConnectionStrings")["RabbitMQ"]!)
            };

            var connection = connectionFactory.CreateConnection();

            channel = connection.CreateModel();


            return base.StartAsync(cancellationToken);
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += Consumer_Received1;

            channel.BasicConsume(QueueName, false, consumer);
        }

        private void Consumer_Received1(object? sender, BasicDeliverEventArgs e)
        {
            var messageAsJson = Encoding.UTF8.GetString(e.Body.ToArray());

            var userCreatedEvent = JsonSerializer.Deserialize<UserCreatedEvent>(messageAsJson);


            Console.WriteLine($"Email gönderilmi?tir.{userCreatedEvent.Email}");

            channel.BasicAck(e.DeliveryTag, false);
        }
    }
}