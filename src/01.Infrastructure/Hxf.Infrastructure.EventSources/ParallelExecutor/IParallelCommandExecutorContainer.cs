using System.Threading.Tasks;
using Hxf.Infrastructure.Validation;

namespace Hxf.Infrastructure.EventSources.ParalleExecutor {
    public interface IParallelCommandExecutorContainer {
        Task<JsonResponse> DoExecutorParallel(ICommand command);
        IParallelCommandExecutorContainer RegisterExecutor<TExecutor>() where TExecutor : class, IParallelCommandExecutor;
    }
}