using System.Collections.Generic;
using System.Security.Claims;

namespace Wtalk.Core.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(int userId, string email);
        IEnumerable<Claim> ReadToken(string token);
        int ReadCompanyId(string token);
        int ReadUserId(string token);
    }
}
