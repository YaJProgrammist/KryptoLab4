using Blake3Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Part1
{
    public class Blake3Hasher
    {
        private const string OUTPUT_PATH = "../../../HashesBlake3.csv";

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
            Blake3 blake3 = new Blake3();
            byte[] hash = blake3.ComputeHash(Encoding.UTF8.GetBytes(str));

            return Convert.ToBase64String(hash);
        }
    }
}
