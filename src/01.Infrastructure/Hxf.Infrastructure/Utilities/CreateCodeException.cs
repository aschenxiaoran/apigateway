using Hxf.Infrastructure.Exceptions;

namespace Hxf.Infrastructure.Utilities{
    public class CreateCodeException : DomainException {

        public CreateCodeException() {
            AddError((CodeUtility unity) => unity.Code, 11, "编号异常，请联系管理员", true);
        }
    }
}