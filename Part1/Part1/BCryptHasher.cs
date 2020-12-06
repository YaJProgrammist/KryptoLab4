using System.Collections.Generic;
using System.IO;

namespace Part1
{
    public class BCryptHasher
    {
        private const string OUTPUT_PATH = "../../../HashesBCrypt.csv";

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
            return BCrypt.Net.BCrypt.HashPassword(str);
        }
    }
}
