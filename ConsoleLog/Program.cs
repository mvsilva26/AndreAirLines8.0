﻿using ConsoleLog.Service;
using Models.Model;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

namespace ConsoleLog
{
    internal class Program
    {
        private const string QUEUE_NAME = "messagelogs";

        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: QUEUE_NAME,
                                  durable: false,
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null);

                    while (true)
                    {
                        var consumer = new EventingBasicConsumer(channel);
                        consumer.Received += async (model, ea) =>
                        {
                            var body = ea.Body.ToArray();
                            var returnMessage = Encoding.UTF8.GetString(body);
                            var message = JsonConvert.DeserializeObject<Log>(returnMessage);
                            await SenderSQLServerService.Add(message);
                        };

                        channel.BasicConsume(queue: QUEUE_NAME,
                                             autoAck: true,
                                             consumer: consumer);

                        Thread.Sleep(2000);
                    }
                }
            }



        }
    }
}
