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
            channel.QueueDeclare("Basic Test", false, false, false, null);
        };
    }
}