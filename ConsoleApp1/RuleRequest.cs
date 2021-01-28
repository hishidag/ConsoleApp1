namespace ConsoleApp1
{
    public class RuleRequest
    {
        public string Secret { get; private set; }
        public string Guess { get; private set; }

        public RuleRequest(string secret, string guess)
        {
            Secret = secret;
            Guess = guess;
        }

    }

}
