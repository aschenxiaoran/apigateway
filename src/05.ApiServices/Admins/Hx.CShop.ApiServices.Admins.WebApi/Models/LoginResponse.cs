using System;
using System.Collections.Generic;

namespace Hx.CShop.ApiServices.Admins.WebApi.Models {
    public class LoginResponse {
        public bool IsError { get; set; }
        public string Error { get; set; }
        public string LoginName{get;set;}
        public string UserName { get; set; }
        public string Email{get;set;}
        public string Token { get; set; }
        public List<MenuResponse> Menus{get;set;}
    }
}