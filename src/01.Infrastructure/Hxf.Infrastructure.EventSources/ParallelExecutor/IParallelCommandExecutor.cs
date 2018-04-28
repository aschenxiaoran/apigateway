using System.Threading.Tasks;
using Hxf.Infrastructure.Data;

namespace Hxf.Infrastructure.EventSources.ParalleExecutor {
    public interface IParallelCommandExecutor {
        Task Excute(ICommand command);
    }
}