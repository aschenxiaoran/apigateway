using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hx.CShop.ApiServices.Admins.Commands;
using Hxf.Infrastructure.EventSources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Hx.CShop.ApiServices.Admins.WebApi.Controllers {

    [Route("api/[controller]")]

    // [Authorize]
    public class ValuesController : Controller {
        private readonly CommandBus _commandBus;

        public ValuesController() {
            _commandBus = new CommandBus();
        }

        // GET api/values

        [HttpGet]
        public async Task<IEnumerable<string>> Get() {
            var command = new NewMenuCommand {
                Code = "xxx"
            };

            Log.Information("Controller");
            await _commandBus.Register<NewMenuCommand>()
                .Register<NewMenuCommand>()
                .Send(command);

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5

        [HttpGet("{id}")]
        public string Get(int id) {
            return "value";
        }

        // POST api/values

        [HttpPost]
        public void Post([FromBody] string value) {}

        // PUT api/values/5

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {}

        // DELETE api/values/5

        [HttpDelete("{id}")]
        public void Delete(int id) {}
    }
}