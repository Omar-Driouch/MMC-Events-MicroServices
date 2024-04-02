using System;
using System.Text;
using System.Threading.Tasks;
using EventService.Application.Interfaces;
using Newtonsoft.Json;

using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class RabbitMQServer
{
    private readonly IModel channel;
    private readonly IUnitOfService _service;

    public RabbitMQServer(IUnitOfService service)
    {
        _service = service;
        var factory = new ConnectionFactory() { HostName = "localhost", Password = "guest", UserName = "guest" };
        var connection = factory.CreateConnection();
        channel = connection.CreateModel();

        channel.QueueDeclare(queue: "ServiceEvent", durable: false, exclusive: false, autoDelete: false, arguments: null);
        channel.BasicQos(0, 1, false);

        var consumer = new EventingBasicConsumer(channel);
        channel.BasicConsume(queue: "ServiceEvent", autoAck: false, consumer: consumer);
        // Configure JSON serialization settings to ignore reference loops
        

        consumer.Received += async (model, ea) =>
        {
            string response = "";
            var body = ea.Body.ToArray();
            Console.WriteLine(body); 

            var props = ea.BasicProperties;
            var replyProps = channel.CreateBasicProperties();
            replyProps.CorrelationId = props.CorrelationId;

            try
            {
                object data = null; 
                var message = Encoding.UTF8.GetString(body);
                var dd = message.Split("/");

               
                switch (dd[0])
                {
                    case "Event":
                        data = dd[1] == "all" ? await _service.EventService.FindAllAsync() :
                                                await _service.EventService.FindAsync(Guid.Parse(dd[1]));
                        break;
                    case "Session":
                        data = dd[1] == "all" ? await _service.SessionService.FindAllAsync() :
                                                await _service.SessionService.FindAsync(Guid.Parse(dd[1]));
                        break;
                    case "Program":
                        data = dd[1] == "all" ? await _service.ProgramService.FindAllAsync() :
                                                await _service.ProgramService.FindAsync(Guid.Parse(dd[1]));
                        break;
                    default:
                        throw new ArgumentException("Invalid request type");
                }

                
                var jsonData = JsonConvert.SerializeObject(data, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
                var responseBytes = Encoding.UTF8.GetBytes(jsonData);
                channel.BasicPublish(exchange: "", routingKey: props.ReplyTo, basicProperties: replyProps, body: responseBytes);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                var responseBytes = Encoding.UTF8.GetBytes("Error");
                channel.BasicPublish(exchange: "", routingKey: props.ReplyTo, basicProperties: replyProps, body: responseBytes);
            }
            finally
            {
                channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
            }
        };


    }

    public void Close()
    {
        channel.Close();
    }
}
