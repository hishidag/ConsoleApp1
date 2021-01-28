using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    // Chain of Responsibility
    abstract class Rule
    {
        private Rule nextRule;
        protected string info;

        public Rule()
        {
        }

        abstract public bool CanApply(string secret, string guess);

        public Rule ChainRule(Rule next)
        {
            this.nextRule = next;
            return next;
        }

        public string Apply(string secret, string guess)
        {
            if (CanApply(secret, guess)) return info;
            return nextRule?.Apply(secret, guess);
        }

    }

    class NumericRule : Rule
    {
        public NumericRule() : base()
        {
            base.info = "数字を入力してください";
        }

        public override bool CanApply(string secret, string guess)
        {
            return !int.TryParse(guess, out int _);
        }
    }

    class DigitsRule : Rule
    {
        public DigitsRule() : base() { }

        public override bool CanApply(string secret, string guess)
        {
            base.info = $"シークレットは{secret.Length}桁です";
            return secret.Length != guess.Length;
        }
    }

    class MatchRule : Rule
    {
        public MatchRule() : base() 
        {
            base.info = "Bingo!!!";
        }

        public override bool CanApply(string secret, string guess)
        {
            return secret.Equals(guess);
        }

    }

    class GameRule : Rule
    {
        public GameRule() : base() { }

        public override bool CanApply(string secret, string guess)
        {
            int bulls = 0, cows = 0;
            int[] count = new int[10];

            for (int i = 0; i < secret.Length; i++)
            {
                if (secret[i] == guess[i]) bulls++;
                else
                {
                    if (count[secret[i] - '0']++ < 0) cows++;
                    if (count[guess[i] - '0']-- > 0) cows++;
                }
            }

            base.info = $"{bulls}A{cows}B";

            return true;
        }
    }

}
