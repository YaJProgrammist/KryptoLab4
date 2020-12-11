using System;
using System.Collections.Generic;
using System.IO;

namespace Part1
{
    public class PasswordFileGenerator : PasswordTypeGenerator
    {
        private Random rand;

        public List<string> PaswordList { get; private set; }

        public PasswordFileGenerator(string fileName)
        {
            FillPasswordsList(fileName);
            rand = new Random();
        }
        public override string GetRandomPassword()
        {
            return PaswordList[rand.Next(PaswordList.Count)];
        }

        private void FillPasswordsList(string fileName)
        {
            PaswordList = new List<string>();
            StreamReader sr = new StreamReader(fileName);

            while (!sr.EndOfStream)
            {
                string password = sr.ReadLine();
                if (password.Length > 0)
                {
                    PaswordList.Add(password);
                }
            }

            sr.Close();
        }
    }
}
