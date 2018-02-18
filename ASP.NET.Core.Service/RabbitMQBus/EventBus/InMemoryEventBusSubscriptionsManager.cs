using ASP.NET.Core.Service.RabbitMQBus.EventBus.Abstractions;
using ASP.NET.Core.Service.RabbitMQBus.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASP.NET.Core.Service.RabbitMQBus.EventBus
{
    public class InMemoryEventBusSubscriptionsManager : IEventBusSubscriptionsManager
    {
        private readonly Dictionary<string, List<SubscriptionInfo>> _handlers;
        private readonly List<Type> _eventTypes;

        public event EventHandler<string> OnEventRemoved;
        public bool IsEmpty => !_handlers.Keys.Any();

        public bool HasSubscriptionsForEvent(string eventName) => _handlers.ContainsKey(eventName);

        public Type GetEventTypeByName(string eventName) => _eventTypes.SingleOrDefault(t => t.Name == eventName);
       
        public void Clear() => _handlers.Clear();

        public IEnumerable<SubscriptionInfo> GetHandlersForEvent(string eventName) => _handlers[eventName];

        public InMemoryEventBusSubscriptionsManager()
        {
            _handlers = new Dictionary<string, List<SubscriptionInfo>>();
            _eventTypes = new List<Type>();
        }

        public void AddSubscription<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>
        {
            var eventName = GetEventKey<T>();
            var handlerType = typeof(T);

            if (!HasSubscriptionsForEvent(eventName))
            {
                _handlers.Add(eventName, new List<SubscriptionInfo>());
            }

            if (_handlers[eventName].Any(s => s.HandlerType == handlerType))
            {
                throw new ArgumentException(
                    $"Handler Type {handlerType.Name} already registered for '{eventName}'", nameof(handlerType));
            }

            _handlers[eventName].Add(SubscriptionInfo.Typed(handlerType));

            _eventTypes.Add(typeof(T));
        }

        public string GetEventKey<T>()
        {
            return typeof(T).Name;
        }

        private void RaiseOnEventRemoved(string eventName)
        {
            var handler = OnEventRemoved;
            if (handler != null)
            {
                OnEventRemoved(this, eventName);
            }
        }

        public class SubscriptionInfo
        {
            public Type HandlerType { get; }

            private SubscriptionInfo(Type handlerType)
            {
                HandlerType = handlerType;
            }

            public static SubscriptionInfo Typed(Type handlerType)
            {
                
                return new SubscriptionInfo(handlerType);
            }
        }
    }
}
