using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wtalk.Core.Interfaces.Services
{
    public interface IDataProtectionService
    {
        public string GenerateSalt();
        public string Hash(string password, string salt);
        public string Encrypt(string plainText);
        public string Decrypt(string cipherText);

    }
}
