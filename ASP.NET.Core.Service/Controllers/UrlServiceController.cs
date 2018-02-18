using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.NET.Core.Service.Controllers
{
    [Route("api/[controller]")]
    public class UrlServiceController : Controller
    {
        private readonly IActionDescriptorCollectionProvider _provider;

        public UrlServiceController(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            _provider = actionDescriptorCollectionProvider;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            var routes = _provider.ActionDescriptors.Items.Select(x => new {
                
                Action = x.RouteValues["Action"],
                Controller = x.RouteValues["Controller"],
                Name = x.AttributeRouteInfo.Name,
                Template = x.AttributeRouteInfo.Template
            }).ToList();
            return Ok(routes);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
