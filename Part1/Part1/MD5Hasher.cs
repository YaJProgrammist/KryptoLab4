using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Part1
{
    public class MD5Hasher
    {
        private const string OUTPUT_PATH = "../../../HashesMD5.csv";

        public void SaveHashesForPasswords(List<string> passwords)
        {
            StreamWriter sw = new StreamWriter(OUTPUT_PATH);

            foreach (string password in passwords)
            {
                sw.WriteLine(GetStringHash(password));
            }

            sw.Close();
        }

        public string GetStringHash(string str)
        {
            MD5 md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));

            return Convert.ToBase64String(hash);
        }
    }
}
