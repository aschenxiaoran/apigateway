using Hxf.Infrastructure.EventSources;

namespace Hx.CShop.ApiServices.Admins.Commands {
    public class NewMenuCommand : ICommand {
        public string Code { get; set; }
        public string Text { get; set; }
    }
}