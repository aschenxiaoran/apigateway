using System.Collections.Generic;
using System.Threading.Tasks;
using Hx.CShop.ApiService.Products.Commands;
using Hxf.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Hxf.Infrastructure.EventSources;

namespace Hx.CShop.Apiservicec.Product.WebApi.Controllers {

    [Route("api/[controller]")]
    [Authorize]
    public class ValuesController : Controller {
        private readonly CommandBus _commandBus;

        public ValuesController(IEntityframeworkContext efContext) {
            _commandBus = new CommandBus();
        }
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<string>> Get() {
            var registerCommand = new RegisterCommand {
                NickName = "01"
            };
            await _commandBus.Register<RegisterCommand>().Send(registerCommand);
            return new string[] { "value12", "value22" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id) {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value) {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value) {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
