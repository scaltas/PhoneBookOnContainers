using RabbitMQ.Client;

namespace Report.API.Events;

public class RabbitHutch
{
    private static ConnectionFactory _factory;
    private static IConnection _connection;
    private static IModel _channel;
    public static IBus CreateBus(string hostName)
    {
        try
        {
            _factory = new ConnectionFactory
            {
                HostName = hostName,
                DispatchConsumersAsync = true
            };
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
            return new RabbitBus(_channel);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw;
        }

    }
    public static IBus CreateBus(
        string hostName,
        ushort hostPort,
        string virtualHost,
        string username,
        string password)
    {
        _factory = new ConnectionFactory
        {
            HostName = hostName,
            Port = hostPort,
            VirtualHost = virtualHost,
            UserName = username,
            Password = password,
            DispatchConsumersAsync = true
        };

        _connection = _factory.CreateConnection();
        _channel = _connection.CreateModel();
        return new RabbitBus(_channel);
    }
}