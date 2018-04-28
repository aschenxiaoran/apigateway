namespace Hxf.Infrastructure.EventSources.ParalleExecutor {
    public class ParallelCommandExecutorConfig {
        private IParallelCommandExecutor _executor;
        public ParallelCommandExecutorConfig(IParallelCommandExecutor executor) {
            _executor = executor;
        }

        public void SetExecutor(IParallelCommandExecutor executor) {
            _executor = executor;
        }

        public IParallelCommandExecutor Executor {
            get { return _executor; }
        }

        public string Name {
            get { return _executor.ToString(); }
        }
    }
}