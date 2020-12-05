using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Part1
{
    class Program
    {
        private const string OUTPUT_PATH = "../../../Out.txt";

        static void Main(string[] args)
        {
            int numOfPasswords = -1;

            while (numOfPasswords < 0)
            {
                Console.WriteLine("Enter number of passwords:");
                string numOfPasswordsString = Console.ReadLine();
                int.TryParse(numOfPasswordsString, out numOfPasswords);
            }

            Stopwatch stopwatch = Stopwatch.StartNew();

            PasswordListGenerator generator = new PasswordListGenerator();
            List<string> passwords = generator.GetPasswordList(numOfPasswords);

            StreamWriter sw = new StreamWriter(OUTPUT_PATH);

            foreach (string password in passwords)
            {
                sw.WriteLine(password);
            }

            sw.Close();

            stopwatch.Stop();
            Console.WriteLine("Generating passwords took {0} seconds.", stopwatch.ElapsedMilliseconds / 1000.0);
            stopwatch.Restart();

            MD5Hasher md5Hasher = new MD5Hasher();
            md5Hasher.SaveHashesForPasswords(passwords);

            stopwatch.Stop();
            Console.WriteLine("Generating MD5 hashes took {0} seconds.", stopwatch.ElapsedMilliseconds / 1000.0);
            stopwatch.Restart();

            SHA1Hasher sha1Hasher = new SHA1Hasher();
            sha1Hasher.SaveHashesForPasswords(passwords);

            stopwatch.Stop();
            Console.WriteLine("Generating SHA1 hashes took {0} seconds.", stopwatch.ElapsedMilliseconds / 1000.0);
            stopwatch.Restart();

            Argon2Hasher argon2Hasher = new Argon2Hasher();
            argon2Hasher.SaveHashesForPasswords(passwords);

            stopwatch.Stop();
            Console.WriteLine("Generating Argon2i hashes took {0} seconds.", stopwatch.ElapsedMilliseconds / 1000.0);
        }
    }
}
