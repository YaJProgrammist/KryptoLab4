namespace Part1
{
    public class PasswordsChank
    {
        public PasswordTypeGenerator PasswordTypeGenerator { get; private set; }
        public double Percent { get; private set; }

        public PasswordsChank(PasswordTypeGenerator passwordTypeGenerator, double percent)
        {
            PasswordTypeGenerator = passwordTypeGenerator;
            Percent = percent;
        }
    }
}
