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
    }
}