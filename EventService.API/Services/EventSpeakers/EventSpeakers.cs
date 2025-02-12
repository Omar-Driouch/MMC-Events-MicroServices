﻿using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using EventService.API.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

public class EventSpeakers : IEventSpeakers
{
    private readonly IConnection connection;
    private readonly IModel channel;
    private readonly string replyQueueName;
    private readonly EventingBasicConsumer consumer;
    private readonly IBasicProperties props;
    private string responseMessage;

    public EventSpeakers() 
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

    public async Task<object> RequestMethod(string Services, string Request)
    {
        var messageBytes = Encoding.UTF8.GetBytes(Services + "/" + Request);
        channel.BasicPublish(
            exchange: "",
            routingKey: "MMC_Event",
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

    public async Task<object> DeleteMethod(string Services, string Request, Guid id)
    {
        var messageBytes = Encoding.UTF8.GetBytes(Services + "/" + Request + "/" + id);
        channel.BasicPublish(
            exchange: "",
            routingKey: "EventToSpeaker",
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
}
