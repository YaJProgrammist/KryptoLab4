using System;
using System.Collections.Generic;
using System.IO;

namespace Part1
{
    public class PasswordHumanLikeGenerator : PasswordTypeGenerator
    {
        private Random rand;

        private const int MIN_PASSWORD_LENGTH = 8;
        private const string COMMON_WORDS_FILE = "../../../MostCommonWords.txt";
        private const string ADDITIONAL_SYMBOLS = "0123456789!@#$%^&*-_";
        private readonly Dictionary<char, char> REPLACEABLE_LETTERS = new Dictionary<char, char>()
        {
            { 'o', '0' }, { 'e', '3' }, { 's', '5' }, { 'i', '1' }, { 'g', '9' },
            { 'O', '0' }, { 'E', '3' }, { 'S', '5' }, { 'I', '1' }, { 'B', '8' }, { 'G', '6' },
        };

        public List<string> CommonWordsList { get; private set; }

        public PasswordHumanLikeGenerator()
        {
            FillCommonWordsList();
            rand = new Random();
        }

        public override string GetRandomPassword()
        {
            string password = string.Empty;

            while (password.Length < MIN_PASSWORD_LENGTH)
            {
                int componentType = rand.Next(2);

                if (componentType == 0)
                {
                    password += CommonWordsList[rand.Next(CommonWordsList.Count)];
                }
                else if (componentType == 1)
                {
                    password += ADDITIONAL_SYMBOLS[rand.Next(ADDITIONAL_SYMBOLS.Length)];
                }
            }

            int transformationNeeded = rand.Next(2);

            if (transformationNeeded == 1)
            {
                password = ReplaceLetters(password);
            }

            return password;
        }

        private string ReplaceLetters(string input)
        {
            string output = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                if (REPLACEABLE_LETTERS.ContainsKey(input[i]))
                {
                    output += REPLACEABLE_LETTERS[input[i]];
                }
                else
                {
                    output += input[i];
                }
            }

            return output;
        }

        private void FillCommonWordsList()
        {
            CommonWordsList = new List<string>();
            StreamReader sr = new StreamReader(COMMON_WORDS_FILE);

            while (!sr.EndOfStream)
            {
                string password = sr.ReadLine();
                if (password.Length > 0)
                {
                    CommonWordsList.Add(password);
                }
            }

            sr.Close();
        }
    }
}
