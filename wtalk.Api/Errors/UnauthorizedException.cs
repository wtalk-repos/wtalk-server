using System;

namespace Wtalk.Api.Errors
{
    public class UnauthorizedException : GlobalException
    {
        public UnauthorizedException(string code, string message) : base(code, message)
        {
        }

        public UnauthorizedException(string code, string message, Exception innerException) : base(code, message, innerException)
        {
        }
    }
}
