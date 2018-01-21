using RabbitMQ.Client;
using System;

namespace ASP.NET.Core.Service.RabbitMQBus.EventBusRabbitMQ
{
    public interface IRabbitMQPersistentConnection
        : IDisposable
    {
        bool IsConnected { get; }

        bool TryConnect();

        IModel CreateModel();
    }
}
