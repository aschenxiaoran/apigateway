using System;

namespace Hx.CShop.ApiServices.Admins.WebApi.Models {
    public class AuthenticationServerConfig {
        public string Url { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}