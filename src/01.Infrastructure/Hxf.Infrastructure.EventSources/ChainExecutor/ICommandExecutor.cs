using System.Threading.Tasks;
using Hxf.Infrastructure.Data;

namespace Hxf.Infrastructure.EventSources.ChainExecutor {

    public interface ICommandExecutor {
        IEntityframeworkContext DbContext { get; }
        Task Excute(ICommand command, CommandContext context);
    }

}