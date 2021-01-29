using System;
using System.Collections.Generic;
using System.Linq;

namespace BullsAndCowsGame
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
            secret = OfferSecret.Secret;
        }

        public (string, bool) Guess(string guess)
        {
            RuleResponse response = rules.Apply(new RuleRequest(secret, guess));
            return (response.Info ?? "", response.Cleared);
        }

        public void ChangeSecretStrategy(GameStrategy strategy)
        {
            OfferSecret.ChangeStrategy(strategy);
        }

    }
}
