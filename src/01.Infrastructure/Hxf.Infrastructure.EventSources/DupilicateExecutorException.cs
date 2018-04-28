using Hxf.Infrastructure.Exceptions;

namespace Hxf.Infrastructure.EventSources {
    public class DupilicateExecutorException : DomainException {
        public DupilicateExecutorException() {
            AddError((AggregateRoot entity) => entity, string.Empty, "明细不能为空", true);
        }
    }
}