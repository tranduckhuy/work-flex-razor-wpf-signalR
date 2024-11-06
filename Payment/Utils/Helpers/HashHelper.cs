using System.Text;

namespace WorkFlex.Payment.Utils.Helpers
{
    public static class HashHelper
    {
        public static string HmacSHA256(string data, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            using (var hmacSha256 = new System.Security.Cryptography.HMACSHA256(keyBytes))
            {
                byte[] hashBytes = hmacSha256.ComputeHash(dataBytes);
                string hex = BitConverter.ToString(hashBytes).Replace("-", string.Empty).ToLower();
                return hex;
            }
        }
    }
}
