using System.Threading.Tasks;
using Hx.CShop.ApiServices.Admins.Commands;
using Hxf.Infrastructure.EventSources;

namespace Hx.CShop.ApiServices.Admins.Executors
{
    public class NullCommandExecutor : ICommandExecutor<NullCommand>
    {
        public Task ExcuteAsync(ICommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}