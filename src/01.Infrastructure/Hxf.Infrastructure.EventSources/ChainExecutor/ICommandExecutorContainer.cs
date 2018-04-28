using System;
using System.Threading.Tasks;
using Hxf.Infrastructure.Data;
using Hxf.Infrastructure.Validation;

namespace Hxf.Infrastructure.EventSources.ChainExecutor {
    public interface ICommandExecutorContainer {
        CommandContext CommandContext { get; }
        Task<JsonResponse> DoExecutor(ICommand command);
        Task<JsonResponse> DoExecutorTransaction(ICommand command);
        ICommandExecutorContainer RegisterExecutor<TExecutor>() where TExecutor : class, ICommandExecutor;
    }
}