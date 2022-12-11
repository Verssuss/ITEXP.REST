using Application.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace ITEXP.REST_API
{
    public class MD5Crypt : ICrypt
    {
        public string Crypt(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }
    }
}