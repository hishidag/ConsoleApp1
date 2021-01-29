using System;

namespace BullsAndCows
{
    public class Game
    {
        string secret;
        readonly Rule rules = RuleBuilder.GetRule();

        public Game()
        {
            Start();
        }

        public void Start()
        {
            secret = "1234";// NewSecretString();
        }

        public (string, bool) Guess(string guess)
        {
            RuleResponse response = rules.Apply(new RuleRequest(secret, guess));
            return (response.Info ?? "", response.Cleared);
        }

        private string NewSecretString()
        {
            return NewSecretNumber().ToString().PadLeft(4, '0');
        }

        private int NewSecretNumber()
        {
            return new Random().Next(0, (int)Math.Pow(10,4));
        }

    }
}
