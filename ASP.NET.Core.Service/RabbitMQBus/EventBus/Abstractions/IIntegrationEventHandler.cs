using ASP.NET.Core.Service.RabbitMQBus.EventBus.Events;
using System.Threading.Tasks;

namespace ASP.NET.Core.Service.RabbitMQBus.EventBus.Abstractions
{
    public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler 
        where TIntegrationEvent: IntegrationEvent
    {
        Task Handle(TIntegrationEvent @event);
    }

    public interface IIntegrationEventHandler
    {
    }
}
