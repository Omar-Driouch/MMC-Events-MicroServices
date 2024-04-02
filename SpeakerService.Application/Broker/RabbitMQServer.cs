using System;
using System.Text;
using System.Threading.Tasks;
using SpeakerService.Application.Interfaces;
using Newtonsoft.Json;

using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class RabbitMQServer
{
    private readonly IModel channel;
  
    private  ISpeakerService _service;
    private IEventSpeakerServices _eventSpeakerServices;

    public RabbitMQServer(IEventSpeakerServices eventSpeakerServices)
    {
        _eventSpeakerServices = eventSpeakerServices;
        var factory = new ConnectionFactory() { HostName = "localhost", Password = "guest", UserName = "guest" };
        var connection = factory.CreateConnection();
        channel = connection.CreateModel();

        channel.QueueDeclare(queue: "EventToSpeaker", durable: false, exclusive: false, autoDelete: false, arguments: null);
        channel.BasicQos(0, 1, false);

        var consumer = new EventingBasicConsumer(channel);
        channel.BasicConsume(queue: "EventToSpeaker", autoAck: false, consumer: consumer);



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
                    case "Speaker":
                        if (dd.Length >= 3 && dd[1] == "Delete" && !string.IsNullOrEmpty(dd[2]))
                        {
                            if (Guid.TryParse(dd[2], out Guid g))
                            {
                                data = _eventSpeakerServices.DeleteEventFromSpeakerEvent(g);
                            }
                            else
                            {
                                throw new ArgumentException("Invalid GUID format");
                            }
                        }

                        break;
                    default:
                        throw new ArgumentException("Invalid request type");
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

    public void Close()
    {
        channel.Close();
    }
}
