using System.Security.Cryptography;
using System.Text;

namespace TrackITManagementSystem
{
    class HashPassword
    {
        //Hashing Method
        public static string CalculateSHA256(string str)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] hashValue;
            hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(str));
            //Convert byte array to a string
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hashValue.Length; i++)
            {
                builder.Append(hashValue[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
