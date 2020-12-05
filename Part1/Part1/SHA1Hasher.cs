using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Part1
{
    public class SHA1Hasher
    {
        private const string OUTPUT_PATH = "../../../HashesSHA1.csv";
        private static readonly RandomNumberGenerator Rng = RandomNumberGenerator.Create();

        public void SaveHashesForPasswords(List<string> passwords)
        {
            StreamWriter sw = new StreamWriter(OUTPUT_PATH);

            foreach (string password in passwords)
            {
                Tuple<string, string> hashAndSalt = GetStringHashAndSalt(password);
                sw.WriteLine("{0};{1}", hashAndSalt.Item1, hashAndSalt.Item2);
            }

            sw.Close();
        }

        public Tuple<string, string> GetStringHashAndSalt(string str)
        {
            SHA1 sha1 = SHA1.Create();

            byte[] salt = new byte[16];
            Rng.GetBytes(salt);

            string stringSalt = Convert.ToBase64String(salt);

            byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(str + stringSalt));

            return new Tuple<string, string>(Convert.ToBase64String(hash), stringSalt);
        }
    }
}
