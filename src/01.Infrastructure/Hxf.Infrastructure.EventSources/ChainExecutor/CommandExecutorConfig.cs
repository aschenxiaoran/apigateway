namespace Hxf.Infrastructure.EventSources.ChainExecutor {
    public class CommandExecutorConfig {
        private ICommandExecutor _executor;
        public CommandExecutorConfig(ICommandExecutor executor) {
            _executor = executor;
        }

        public void SetExecutor(ICommandExecutor executor) {
            _executor = executor;
        }

        public ICommandExecutor Executor => _executor;

        public string Name => _executor.ToString();
    }
}