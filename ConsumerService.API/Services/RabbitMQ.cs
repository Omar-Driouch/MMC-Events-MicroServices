﻿using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace ConsumerService.API.Services
{
    public class RpcClient : IRabbitMQ
    {
        private readonly IConnection connection;
        private readonly IModel channel;
        private readonly string replyQueueName;
        private readonly EventingBasicConsumer consumer;
        private readonly IBasicProperties props;
        private string responseMessage;

        public RpcClient()
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

        public string Call(string Services, string message)
        {
            var messageBytes = Encoding.UTF8.GetBytes(Services + "/"+ message );
            channel.BasicPublish(
                exchange: "",
                routingKey: "MMC",
                basicProperties: props,
                body: messageBytes);

            
            while (responseMessage == null)
            {
                Thread.Sleep(100);   
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
}
