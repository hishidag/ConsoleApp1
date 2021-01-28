using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Game
    {
        string secret;
        readonly Rule rules = RuleBuilder.GetRule();

        public Game()
        {
            Start();
        }

        public void Start()
        {
            secret = "1234";
        }

        public (string, bool) Guess(string guess)
        {
            RuleResponse response = rules.Apply(new RuleRequest(secret, guess));
            return (response.Info ?? "", response.Cleared);
        }

    }
}
