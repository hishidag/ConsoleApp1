using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class RuleBuilder
    {
        public static Rule GetRule()
        {
            Rule firstRule = new NumericRule();

            firstRule.ChainRule(new DigitsRule())
                     .ChainRule(new MatchRule())
                     .ChainRule(new GameRule());

            return firstRule;
        }
    }
}
