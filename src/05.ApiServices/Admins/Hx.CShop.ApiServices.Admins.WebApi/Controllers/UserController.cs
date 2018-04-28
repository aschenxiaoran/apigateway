using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hx.CShop.ApiServices.Admins.WebApi.Controllers {
    [Route ("api/[controller]")]
    [Authorize]
    public class UserController : Controller {

        [HttpGet]
        public IActionResult Get () {
            var claim = User.Claims.Where(l => l.Type == "sub").FirstOrDefault();
            return new JsonResult(new {UserId = claim.Value});
        }
    }
}