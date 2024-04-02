using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ParamsService.API.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

public class NotificationsServer : INotificationsServer
{
    private readonly IConnection connection;
    private readonly IModel channel;
    private readonly string replyQueueName;
    private readonly EventingBasicConsumer consumer;
    private readonly IBasicProperties props;
    private string responseMessage;

    public NotificationsServer() 
    {
        var factory = new ConnectionFactory() { HostName = "localhost", Password = "guest", UserName = "guest" };

        connection = factory.CreateConnection();
        channel = connection.CreateModel();
        replyQueueName = channel.QueueDeclare().QueueName;
        consumer = new EventingBasicConsumer(channel);

        props = channel.CreateBasicProperties();
        var correlationId = Guid.NewGuid().ToString();
        props.CorrelationId = correlationId;
        props.ReplyTo = replyQueueName;

        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            responseMessage = Encoding.UTF8.GetString(body);
            if (ea.BasicProperties.CorrelationId == correlationId)
            {
                Console.WriteLine("Response: " + responseMessage);
            }
        };

        channel.BasicConsume(
            consumer: consumer,
            queue: replyQueueName,
            autoAck: true);
    }

    public async Task<object> SendNotificationVia(string ServicesOfNotification, string ParticipantID, string EventID)
    {
        var messageBytes = Encoding.UTF8.GetBytes(ServicesOfNotification + "/" + ParticipantID + "/" + EventID);
        channel.BasicPublish(
            exchange: "",
            routingKey: "Nofitication",
            basicProperties: props,
            body: messageBytes);

        while (responseMessage == null)
        {
            await Task.Delay(100);
        }

        var response = responseMessage;
     
        responseMessage = null;

        return response;
    }



    public async Task<object> RequestDatafromParticipants(string Services, string ParticipantID)
    {
        var messageBytes = Encoding.UTF8.GetBytes(Services + "/" + ParticipantID );
        channel.BasicPublish(
            exchange: "",
            routingKey: "ParamsToEvent",
            basicProperties: props,
            body: messageBytes);

        while (responseMessage == null)
        {
            await Task.Delay(100);
        }

        var response = responseMessage;
         
        responseMessage = null;

        return response;
    }

    public void Close()
    {
        connection.Close();
    }
}
