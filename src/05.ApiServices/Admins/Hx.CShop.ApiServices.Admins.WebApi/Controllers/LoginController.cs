using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Hx.CShop.ApiServices.Admins.WebApi.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Hx.CShop.ApiServices.Admins.WebApi.Controllers {
    [Route ("api/[controller]")]
    public class LoginController : Controller {
        private AuthenticationServerConfig authenticationServerConfig;

        public LoginController (IOptions<AuthenticationServerConfig> option) {
            authenticationServerConfig = option.Value;
        }

        [HttpPost]
        public async Task<IActionResult> Login ([FromBody] LoginRequest loginRequest) {
            var loginResponse = new LoginResponse {
                LoginName = loginRequest.UserName
            };
            try {
                //todo:调用user service判断用户名密码是否准确，并获取用户

                if (loginRequest.UserName != "admin" || loginRequest.Password != "admin") {
                    throw new LoginErrorExcption ("用户名或密码错误");
                }

                var token = await GetToken (10086);
                var tokenNotValid = string.IsNullOrWhiteSpace (token);
                loginResponse.IsError = tokenNotValid ? true : false;
                loginResponse.Error = tokenNotValid ? "获取token失败" : string.Empty;
                loginResponse.Token = token;
                loginResponse.UserName = "test";
                loginResponse.Email = "10086@10086.com";
                loginResponse.Menus = FakeMenuProvider.GetMenus();

            } catch (LoginErrorExcption loginError) {
                loginResponse.IsError = true;
                loginResponse.Error = loginError.Message;
            } catch (System.Exception e) {
                loginResponse.IsError = true;
                loginResponse.Error = "登陆异常" + e.Message;
            }
            return new JsonResult (loginResponse);
        }

        private async Task<string> GetToken (int userId) {
            var client = new DiscoveryClient (authenticationServerConfig.Url) {
                Policy = {
                RequireHttps = false
                }
            };
            var disco = await client.GetAsync ();

            var tokenClient = new TokenClient (disco.TokenEndpoint, authenticationServerConfig.ClientId, authenticationServerConfig.ClientSecret);
            var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync (userId.ToString (), authenticationServerConfig.Password);

            if (tokenResponse.IsError) {
                return string.Empty;
            } else {
                return tokenResponse.AccessToken;
            }
        }
    }

    public class LoginErrorExcption : Exception {
        public LoginErrorExcption (string message) : base (message) {

        }
    }
}