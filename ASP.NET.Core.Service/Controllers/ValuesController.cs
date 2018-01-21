using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET.Core.Service.RabbitMQBus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace ASP.NET.Core.Service.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IDistributedCache _distributedCache;

        public ValuesController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        // GET api/values/5
        [HttpGet("{key}")]
        public async Task<string> Get(string key)
        {
            return await _distributedCache.GetStringAsync(key);
        }
    }
}
