using ASP.NET.Core.Service.RabbitMQBus.EventBus.Abstractions;
using ASP.NET.Core.Service.RabbitMQBus.EventBus.Events;
using System;
using System.Collections.Generic;
using static ASP.NET.Core.Service.RabbitMQBus.EventBus.InMemoryEventBusSubscriptionsManager;

namespace ASP.NET.Core.Service.RabbitMQBus.EventBus
{
    public interface IEventBusSubscriptionsManager
    {
        bool IsEmpty { get; }
        event EventHandler<string> OnEventRemoved;

        void AddSubscription<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>;

        bool HasSubscriptionsForEvent(string eventName);
        Type GetEventTypeByName(string eventName);
        void Clear();

        IEnumerable<SubscriptionInfo> GetHandlersForEvent(string eventName);
        string GetEventKey<T>();
    }
}