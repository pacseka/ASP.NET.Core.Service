using ASP.NET.Core.Service.RabbitMQBus.EventBus.Abstractions;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace ASP.NET.Core.Service.RabbitMQBus.CustomEvent
{
    public class NinjaKilledChangedEventHandler : IIntegrationEventHandler<NinjaKilledChangedEvent>
    {
        private readonly IDistributedCache _distributedCache;

        public NinjaKilledChangedEventHandler(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task Handle(NinjaKilledChangedEvent @event)
        {
            string message = JsonConvert.SerializeObject(@event, Formatting.Indented);

            string key = "NinjaMessage";

            await _distributedCache.SetStringAsync(key, message);

        }
    }
}
