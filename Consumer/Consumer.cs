﻿using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Consumer;

public class Consumer
{
    private static void Main()
    {
        ConnectionFactory factory = new()
        {
            HostName = "localhost"
        };

        using var connection = factory.CreateConnection();
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare("BasicTest", false, false, false, null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine("Received message {0}...", message);
                ;
            };

            channel.BasicConsume("BasicTest", true, consumer);

            Console.WriteLine("Press [enter] to exit the Consumer App...");
            Console.ReadLine();
        };
    }
}