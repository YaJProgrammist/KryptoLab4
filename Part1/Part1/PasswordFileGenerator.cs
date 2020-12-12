using System;
using System.Collections.Generic;
using System.IO;

namespace Part1
{
    public class PasswordFileGenerator : PasswordTypeGenerator
    {
        private Random rand;

        public List<string> PasswordList { get; private set; }

        public PasswordFileGenerator(string fileName)
        {
            FillPasswordsList(fileName);
            rand = new Random();
        }
        public override string GetRandomPassword()
        {
            return PasswordList[rand.Next(PasswordList.Count)];
        }

        private void FillPasswordsList(string fileName)
        {
            PasswordList = new List<string>();
            StreamReader sr = new StreamReader(fileName);

            while (!sr.EndOfStream)
            {
                string password = sr.ReadLine();
                if (password.Length > 0)
                {
                    PasswordList.Add(password);
                }
            }

            sr.Close();
        }
    }
}
