using System.Security.Cryptography;
using System.Text;

namespace Core.Features.Codes
{
    public class CodeGenerator : ICodeGenerator
    {
        private readonly char[] CHARS;

        public CodeGenerator()
        {
            CHARS = "ABCDEFGHJKLMNPQRSTUVWXYZ1234567890".ToCharArray();
        }

        public string Generate(int length)
        {
            var data = new byte[length];
            using (var crypto = RandomNumberGenerator.Create())
            {
                crypto.GetBytes(data);
            }
            var result = new StringBuilder(length);
            foreach (var b in data)
            {
                result.Append(CHARS[b % (CHARS.Length)]);
            }
            return result.ToString();
        }
    }
}