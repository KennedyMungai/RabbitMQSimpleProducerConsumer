using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Consumer;

public class Consumer
{
    private static void Main(string[] args)
    {
        ConnectionFactory factory = new ConnectionFactory()
        {
            HostName = "localhost"
        };
    }
}