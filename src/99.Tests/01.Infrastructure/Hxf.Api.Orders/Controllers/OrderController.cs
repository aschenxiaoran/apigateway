using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Hxf.Api.Orders.Controllers {
    [Produces("application/json")]
    [Route("admin/api/Order")]
    public class OrderController : Controller {
        [HttpGet]
        public JsonResult Get() {
            var product = new Product {
                Code = "1111",
                Name = "1111",
            };
            var settings = new JsonSerializerSettings {
                ContractResolver = new DefaultContractResolver()
            };
            return Json(product, settings);
        }

        [HttpGet("{id}")]
        public JsonResult GetAll(int id)
        {
            var product = new Product {
                Code = "1111",
                Name = "1111",
            };
            var settings = new JsonSerializerSettings {
                ContractResolver = new DefaultContractResolver()
            };
            return Json(product, settings);
        }
    }

    public class Product {
        public string Name { get; set; }
        public string Code { get; set; }
    }


}