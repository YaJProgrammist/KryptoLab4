using System;
using System.Collections.Generic;
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

            PasswordListGenerator generator = new PasswordListGenerator();
            List<string> passwords = generator.GetPasswordList(numOfPasswords);

            StreamWriter sw = new StreamWriter(OUTPUT_PATH);

            foreach (string password in passwords)
            {
                sw.WriteLine(password);
            }

            sw.Close();
        }
    }
}
