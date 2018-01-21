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


        void AddSubscription<T, TH>()
           where T : IntegrationEvent
           where TH : IIntegrationEventHandler<T>;

        void RemoveSubscription<T, TH>()
             where TH : IIntegrationEventHandler<T>
             where T : IntegrationEvent;

        bool HasSubscriptionsForEvent<T>() where T : IntegrationEvent;
        bool HasSubscriptionsForEvent(string eventName);
        Type GetEventTypeByName(string eventName);
        void Clear();
        IEnumerable<SubscriptionInfo> GetHandlersForEvent<T>() where T : IntegrationEvent;
        IEnumerable<SubscriptionInfo> GetHandlersForEvent(string eventName);
        string GetEventKey<T>();
    }
}