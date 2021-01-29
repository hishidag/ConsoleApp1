using System;
using System.Collections.Generic;
using System.Linq;

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

        private int NewDistinctSecretNumber()
        {
            int num = 0;
            List<int> numlist = Enumerable.Range(0, 10).ToList();

            while(numlist.Count > 0)
            {
                int takeIndex = new Random().Next(0, numlist.Count);
                num = 10 * num + numlist[takeIndex];
                numlist.RemoveAt(takeIndex);
            }

            return num;
        }

    }
}
