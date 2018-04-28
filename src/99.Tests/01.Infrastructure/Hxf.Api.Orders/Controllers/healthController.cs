using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hxf.Api.Orders.Controllers
{
    [Route("api/[controller]")]
    public class HealthController : Controller {
        [HttpGet("status")]
        public IActionResult Status() => Ok();
    }
}