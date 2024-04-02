using System;
using System.Data.SqlTypes;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ParamsService.Application.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class NotificationToParams
{
    private readonly IModel channel;
    private readonly IUnitOfService _service;

    public NotificationToParams(IUnitOfService service)
    {
        _service = service;
        var factory = new ConnectionFactory() { HostName = "localhost", Password = "guest", UserName = "guest" };
        var connection = factory.CreateConnection();
        channel = connection.CreateModel();

        channel.QueueDeclare(queue: "NotificationToParams", durable: false, exclusive: false, autoDelete: false, arguments: null);
        channel.BasicQos(0, 1, false);

        var consumer = new EventingBasicConsumer(channel);
        channel.BasicConsume(queue: "NotificationToParams", autoAck: false, consumer: consumer);



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
                    case "Theme":
                        data = dd[1] == "all" ? await _service.ThemeService.FindAllAsync() :
                                                await _service.ThemeService.FindAsync(Guid.Parse(dd[1]));
                        break;
                    case "Mode":
                        data = dd[1] == "all" ? await _service.ModeService.FindAllAsync() :
                                                await _service.ModeService.FindAsync(Guid.Parse(dd[1]));
                        break;
                    case "City":
                        data = dd[1] == "all" ? await _service.CityService.FindAllAsync() :
                                                await _service.CityService.FindAsync(Guid.Parse(dd[1]));
                        break;
                    case "Participant":
                        data =    await _service.ParticipantService.FindAsync(Guid.Parse(dd[1]));
                        break;

                    case "Partner":
                        data = dd[1] == "all" ? await _service.PartnerService.FindAllAsync() :
                                                await _service.PartnerService.FindAsync(Guid.Parse(dd[1]));
                        break;
                    case "Sponsor":
                        data = dd[1] == "all" ? await _service.SponsorService.FindAllAsync() :
                                                await _service.SponsorService.FindAsync(Guid.Parse(dd[1]));
                        break;
                    default:
                        data = ("Invalid request type");
                        break;
                }

                var jsonData = JsonConvert.SerializeObject(data);
                var responseBytes = Encoding.UTF8.GetBytes(jsonData);
                channel.BasicPublish(exchange: "", routingKey: props.ReplyTo, basicProperties: replyProps, body: responseBytes);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                var responseBytes = Encoding.UTF8.GetBytes("error");
                channel.BasicPublish(exchange: "", routingKey: props.ReplyTo, basicProperties: replyProps, body: responseBytes);
            }
            finally
            {
                channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
            }
        };


    }

     
}
