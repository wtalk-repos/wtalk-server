namespace Wtalk.Api.Errors
{
    public class BadRequestException : GlobalException
    {
        public BadRequestException(string code, string message) : base(code, message)
        {
        }
    }
}
