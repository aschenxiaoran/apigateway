using Hxf.Infrastructure.EventSources;

namespace Hx.CShop.ApiService.Products.Commands{
    public class RegisterCommand : ICommand {
        public string Email { get; set; }

        public string NickName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }


        public RegisterCommand() {
        }
    }
             
}