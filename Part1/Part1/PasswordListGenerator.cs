using System;
using System.Collections.Generic;

namespace Part1
{
    public class PasswordListGenerator
    {
        private const string TOP_100_PATH = "../../../Top100.csv";
        private const string TOP_1M_PATH = "../../../1M_passwords.txt";
        private const string HUMAN_LIKE_PASSWORDS_PATH = "../../../Human-LikePasswords.txt";

        private Random rand = new Random();

        private readonly List<PasswordsChank> passwordsChunks = new List<PasswordsChank>
            {
                new PasswordsChank(new PasswordFileGenerator(TOP_100_PATH), 5),
                new PasswordsChank(new PasswordFileGenerator(TOP_1M_PATH), 89),
                new PasswordsChank(new PasswordRandomGenerator(), 5),
                new PasswordsChank(new PasswordFileGenerator(HUMAN_LIKE_PASSWORDS_PATH), 1)
            };
        public List<string> PaswordList { get; private set; }

        public List<string> GetPasswordList(int passwordCount)
        {
            List<string> passwords = new List<string>();

            for (int i = 0; i < passwordCount; i++)
            {
                int passTypeInd = rand.Next(99) + 1;

                double currentTypeInd = 0;
                int fileNum = -1;
                while (fileNum < passwordsChunks.Count && passTypeInd > currentTypeInd)
                {
                    fileNum++;
                    currentTypeInd += passwordsChunks[fileNum].Percent;
                }

                passwords.Add(passwordsChunks[fileNum].PasswordTypeGenerator.GetRandomPassword());
            }

            return passwords;
        }
    }
}
