namespace Hxf.Infrastructure.Exceptions {
    public class EmptyItemException: DomainException {

        public EmptyItemException() {
            AddError((AggregateRoot entity) => entity, string.Empty, "明细不能为空", true);
        }
    }
}
