using System.Security;

namespace Utils
{
    public static class CodeGenerator
    {
        public static string GenerateRandomCode()
        {
            string code = Guid.NewGuid().ToString("N");
            return code.Substring(0, 8);
        }
    }
}
