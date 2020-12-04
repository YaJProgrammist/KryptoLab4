using System;
using System.Collections.Generic;

namespace Part1
{
    public class PasswordListGenerator
    {
        private const string TOP_100_PATH = "../../../Top100.csv";
        private const string TOP_1M_PATH = "../../../1M_passwords.txt";
        private const string RANDOM_PASSWORDS_PATH = "../../../RandomPasswords.txt";
        private const string HUMAN_LIKE_PASSWORDS_PATH = "../../../Human-LikePasswords.txt";

        private Random rand = new Random();

        private readonly List<PasswordsFile> passwordsFiles = new List<PasswordsFile>
            {
                new PasswordsFile(TOP_100_PATH, 5),
                new PasswordsFile(TOP_1M_PATH, 89),
                new PasswordsFile(RANDOM_PASSWORDS_PATH, 5),
                new PasswordsFile(HUMAN_LIKE_PASSWORDS_PATH, 1)
            };

        public List<string> GetPasswordList(int passwordCount)
        {
            List<string> passwords = new List<string>();

            for (int i = 0; i < passwordCount; i++)
            {
                int passTypeInd = rand.Next(99) + 1;

                double currentTypeInd = 0;
                int fileNum = -1;
                while (fileNum < passwordsFiles.Count && passTypeInd > currentTypeInd)
                {
                    fileNum++;
                    currentTypeInd += passwordsFiles[fileNum].Percent;
                }

                passwords.Add(passwordsFiles[fileNum].GetRandomPassword());
            }

            return passwords;
        }
    }
}
