using System;

namespace Hx.Infrastructure.Consuls
{
    internal class NullConsulServiceException : Exception
    {
        public NullConsulServiceException()
        {
               
        }

        public NullConsulServiceException(string message) : base(message)
        {
            
        }
    }
}