using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Part1
{
    public class PasswordsFile
    {
        private Random rand;

        public string Name { get; private set; }
        public double Percent { get; private set; }
        public List<string> PaswordList { get; private set; }

        public PasswordsFile(string name, double percent)
        {
            Name = name;
            Percent = percent;

            FillPasswordsList();

            rand = new Random();
        }

        public string GetRandomPassword()
        {
            return PaswordList[rand.Next(PaswordList.Count)];
        }

        private void FillPasswordsList()
        {
            PaswordList = new List<string>();
            StreamReader sr = new StreamReader(Name);

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
