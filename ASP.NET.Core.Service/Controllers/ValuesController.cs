using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ASP.NET.Core.Service.RabbitMQBus;
using ASP.NET.Core.Service.RabbitMQBus.CustomEvent;
using ASP.NET.Core.Service.RabbitMQBus.EventBus.Abstractions;
using ASP.NET.Core.Service.RabbitMQBus.EventBus.Events;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace ASP.NET.Core.Service.Controllers
{
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    public class ValuesController : Controller
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IEventBus _eventBus;

        public ValuesController(IDistributedCache distributedCache, IEventBus eventBus)
        {
            _distributedCache = distributedCache;
            _eventBus = eventBus;
        }

        /// <summary>
        /// Visszadja az adott RabbitMQ Queue üzenetét
        /// </summary>
        /// <param name="key">Routing key</param>
        /// <returns></returns>
        [HttpGet("{key}")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<string> Get(string key)
        {
            return await _distributedCache.GetStringAsync(key);
        }

        public int SetMessage()
        {
            NinjaKilledChangedEvent @event = new NinjaKilledChangedEvent(210, 45, 23);
            _eventBus.Publish(@event);
            return 210;
        }

    }
}
