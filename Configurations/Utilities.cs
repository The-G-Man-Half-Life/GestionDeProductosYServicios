using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace GestionDeProductosYServicios.Configurations;
public class Utilities
{
    public string EncryptpSHA256(string input)
    {
        using (SHA256 SHA256HASH = SHA256.Create())
        {
            byte[] bytes = SHA256HASH.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder builder = new StringBuilder();
            for(int i = 0; i<bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}