using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace Mtf.HardwareKey.Services
{
    public static class HashProvider
    {
        /// <summary>
        /// Creates MD5 hash (128 bit - 16 byte)
        /// </summary>
        /// <param name="input">The string we want to hash</param>
        /// <returns>MD5 hashcode</returns>
        public static string MD5Hash(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var sb = new StringBuilder();
            using (var md5Creator = MD5.Create())
            {
                var data = md5Creator.ComputeHash(Encoding.Default.GetBytes(input));
                for (var i = 0; i < data.Length; i++)
                {
                    _ = sb.Append(data[i].ToString("x2", CultureInfo.InvariantCulture));
                }

                return sb.ToString();
            }
        }
    }
}
