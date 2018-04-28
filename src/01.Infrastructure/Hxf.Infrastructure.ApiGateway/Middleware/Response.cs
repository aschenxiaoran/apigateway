using System.Collections.Generic;

namespace Hxf.Infrastructure.ApiGateway.Middleware {
    public abstract class Response {
        protected Response() {
            Errors = new List<Error>();
        }

        protected Response(IList<Error> errorList) {
            Errors = errorList ?? new List<Error>();
        }

        public IList<Error> Errors { get; }

        public bool IsError => Errors.Count > 0;
    }

    public class Response<T> : Response {
        protected Response(T data) {
            Data = data;
        }

        protected Response(IList<Error> errorList) : base(errorList)
        {
            
        }

        public T Data { get; }
    }
}