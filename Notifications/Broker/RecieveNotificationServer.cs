using System;
using System.Data.SqlTypes;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Notifications.Methods;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class RecieveNotificationServer
{
    private readonly IModel channel;

    EmailServices emailServices = new EmailServices();
    public RecieveNotificationServer(string service)
    {
         
        var factory = new ConnectionFactory() { HostName = "localhost", Password = "guest", UserName = "guest" };
        var connection = factory.CreateConnection();
        channel = connection.CreateModel();

        channel.QueueDeclare(queue: "Nofitication", durable: false, exclusive: false, autoDelete: false, arguments: null);
        channel.BasicQos(0, 1, false);

        var consumer = new EventingBasicConsumer(channel);
        channel.BasicConsume(queue: "Nofitication", autoAck: false, consumer: consumer);



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
                object data = "Hello"; 
                var message = Encoding.UTF8.GetString(body);
                var Methods = message.Split("/");

                switch (Methods[0])
                {
                    case "Email":
                      var issend = await  emailServices.SendEmail(Methods[1], Methods[2]);
                        //call the Email function that taks one args participnat id

                        break;
                }

                var jsonData = JsonConvert.SerializeObject(data);
                var responseBytes = Encoding.UTF8.GetBytes(jsonData);
                channel.BasicPublish(exchange: "", routingKey: props.ReplyTo, basicProperties: replyProps, body: responseBytes);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                var responseBytes = Encoding.UTF8.GetBytes(ex.Message);
                channel.BasicPublish(exchange: "", routingKey: props.ReplyTo, basicProperties: replyProps, body: responseBytes);
            }
            finally
            {
                channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
            }
        };


    }

     
}
