using System;
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

        abstract public bool CanApply();

        public string Apply()
        {
            if (CanApply()) return info;
            return nextRule.Apply();
        }

    }



}
