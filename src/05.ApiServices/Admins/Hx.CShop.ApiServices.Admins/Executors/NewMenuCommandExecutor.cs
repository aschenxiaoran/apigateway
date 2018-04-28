using System.Threading.Tasks;
using Hx.CShop.ApiServices.Admins.Commands;
using Hx.CShop.Repository.Admins;
using Hxf.Infrastructure.Data;
using Hxf.Infrastructure.EventSources;
using Serilog;

namespace Hx.CShop.ApiServices.Admins.Executors {
    public class NewMenuCommandExecutor : ICommandExecutor<NewMenuCommand> {

        public NewMenuCommandExecutor() {
            
        }

        public async Task ExcuteAsync (ICommand command) {
            var newMenuCommand = command as NewMenuCommand;
            Log.Information("Executer");
            await Task.FromResult(0);
        }
    }
}