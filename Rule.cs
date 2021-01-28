﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    // Chain of Responsibility
    abstract class Rule
    {
        Rule nextRule;
        protected string info;

        public Rule(Rule next)
        {
            this.nextRule = next;
        }

        abstract public bool CanApply(string secret, string guess);

        public string Apply(string secret, string guess)
        {
            if (CanApply(secret, guess)) return info;
            return nextRule?.Apply(secret, guess);
        }

    }

    class NumericRule : Rule
    {
        public NumericRule(Rule next) : base(next) 
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
        public DigitsRule(Rule next) : base(next) { }

        public override bool CanApply(string secret, string guess)
        {
            base.info = $"シークレットは{secret.Length}桁です";
            return secret.Length != guess.Length;
        }
    }

    class MatchRule : Rule
    {
        public MatchRule(Rule next) : base(next) 
        {
            base.info = "Bingo!!!";
        }

        public override bool CanApply(string secret, string guess)
        {
            return secret.Equals(guess);
        }

    }



}
