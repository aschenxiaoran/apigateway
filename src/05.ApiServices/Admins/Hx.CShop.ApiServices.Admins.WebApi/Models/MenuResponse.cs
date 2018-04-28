using System;
using System.Collections.Generic;

namespace Hx.CShop.ApiServices.Admins.WebApi.Models {
    public class MenuResponse {
        public string Text { get; set; }
        public int Level { get; set; }
        public string DefaultLink { get; set; }
        public string Link { get; set; }
        public string Icon { get; set; }
        public List<MenuResponse> Children {get;set;}
    }
}