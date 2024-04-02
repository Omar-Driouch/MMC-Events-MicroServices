using Microsoft.AspNetCore.Connections;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace ConsumerService.Controllers
{
    public class MessageBroker
    {
        public string GetMessage()
        {
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "ParamsService",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

               
                var consumer = new EventingBasicConsumer(channel);
                string messageReceived = null;

                
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    messageReceived = message;
                };

                
                channel.BasicConsume(queue: "ParamsService",
                                     autoAck: true,
                                     consumer: consumer);

                
                 

                
                return messageReceived;
            }
        }

    }
}
