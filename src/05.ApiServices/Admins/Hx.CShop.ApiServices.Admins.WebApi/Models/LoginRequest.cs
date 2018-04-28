using System;
using System.Collections.Generic;

namespace Hx.CShop.ApiServices.Admins.WebApi.Models {
    public class LoginRequest {

        public string UserName { get; set; }
        public string Password{get;set;}
    }
}