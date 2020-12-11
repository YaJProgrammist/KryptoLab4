using System;

namespace Part1
{
    public class PasswordRandomGenerator : PasswordTypeGenerator
    {
        private const int PASSWORD_LENGTH = 8;
        private const string SYMBOLS_USED = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private Random rand = new Random();
        public override string GetRandomPassword()
        {
            string password = string.Empty;

            for (int j = 0; j < PASSWORD_LENGTH; j++)
            {
                password += SYMBOLS_USED[rand.Next(SYMBOLS_USED.Length)];
            }

            return password;
        }
    }
}
