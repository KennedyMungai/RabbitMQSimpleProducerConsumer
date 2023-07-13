﻿using System.Text;
using RabbitMQ.Client;

public class Sender
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
            string message = "Getting started with .Net Core RabbitMQ";
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish("", "BasicTest", null, body);
            Console.WriteLine("Sent message {0}...", message);
            ;
        }
}