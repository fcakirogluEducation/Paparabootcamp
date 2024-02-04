using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using TokenAuth.Service.Events;

namespace TokenAuth.Service.Services
{
    public class Bus
    {
        private readonly ConnectionFactory _connectionFactory = new();
        private readonly IModel channel;
        private const string QueueName = "user.created.event.queue";


        public Bus(IConfiguration configuration)
        {
            _connectionFactory.Uri = new Uri(configuration.GetSection("ConnectionStrings")["RabbitMQ"]!);
            var connection = _connectionFactory.CreateConnection();

            channel = connection.CreateModel();

            channel.QueueDeclare(QueueName, durable: true, autoDelete: false, exclusive: false);
        }

        public void Publish(UserCreatedEvent userCreatedEvent)
        {
            var userCreatedEventAsJson = JsonSerializer.Serialize(userCreatedEvent);

            var userCreatedEventAsBinary = Encoding.UTF8.GetBytes(userCreatedEventAsJson);


            channel.BasicPublish("", QueueName, null, userCreatedEventAsBinary);
        }
    }
}