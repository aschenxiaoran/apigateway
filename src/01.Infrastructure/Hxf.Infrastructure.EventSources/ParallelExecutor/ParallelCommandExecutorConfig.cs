namespace Hxf.Infrastructure.EventSources.ParalleExecutor {
    public class ParallelCommandExecutorConfig {

        private IParallelCommandExecutor _executor;

        public ParallelCommandExecutorConfig(IParallelCommandExecutor executor) {
            _executor = executor;
        }

        public IParallelCommandExecutor Executor => _executor;

        public string Name => _executor.ToString();

        public void SetExecutor(IParallelCommandExecutor executor) {
            _executor = executor;
        }
    }
}