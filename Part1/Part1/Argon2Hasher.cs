using Konscious.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Part1
{
    public class Argon2Hasher
    {
        private const string OUTPUT_PATH = "../../../HashesArgon2i.csv";
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
            byte[] passwordBytes = Encoding.UTF8.GetBytes(str);
            var argon2 = new Argon2i(passwordBytes);
            byte[] salt = new byte[16];

            Rng.GetBytes(salt);

            argon2.DegreeOfParallelism = 16;
            argon2.MemorySize = 8192;
            argon2.Iterations = 40;
            argon2.Salt = salt;

            byte[] hash = argon2.GetBytes(128);

            return new Tuple<string, string>(Convert.ToBase64String(hash), Convert.ToBase64String(salt));
        }
    }
}
