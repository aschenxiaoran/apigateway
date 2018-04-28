namespace Hxf.Infrastructure.EventSources.ChainExecutor {
    public class CommandExecutorConfig {
        private ICommandExecutor _executor;
        public CommandExecutorConfig(ICommandExecutor executor) {
            _executor = executor;
        }

        public void SetExecutor(ICommandExecutor executor) {
            _executor = executor;
        }

        public ICommandExecutor Executor {
            get { return _executor; }
        }

        public string Name {
            get { return _executor.ToString(); }
        }
    }
}