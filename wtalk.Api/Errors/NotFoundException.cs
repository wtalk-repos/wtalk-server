namespace Wtalk.Api.Errors
{
    public class NotFoundException : GlobalException
    {
        public NotFoundException(string code, string message) : base(code, message)
        {
        }
    }
}
