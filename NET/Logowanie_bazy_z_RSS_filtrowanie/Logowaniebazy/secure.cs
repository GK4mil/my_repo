using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class secure
    {
        public static string Hash(string pass)
        {
            SHA256 sha = SHA256.Create();
            byte[] passhash = sha.ComputeHash(System.Text.Encoding.Default.GetBytes(pass));
            string sa= Convert.ToBase64String(passhash);
            return sa;
        }
    }
}
