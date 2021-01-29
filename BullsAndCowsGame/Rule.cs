using System;

namespace BullsAndCows
{
    // Chain of Responsibility
    public abstract class Rule
    {
        private Rule nextRule;
        
        public Rule() { }

        abstract protected bool CanApply(RuleRequest request);

        abstract protected RuleResponse MakeRuleResponse(RuleRequest request);

        public Rule ChainRule(Rule next)
        {
            this.nextRule = next;
            return next;
        }

        public RuleResponse Apply(RuleRequest request)
        {
            if (CanApply(request)) return MakeRuleResponse(request);
            else if (!(nextRule is null)) return nextRule.Apply(request);
            else throw new NotImplementedException("");
        }

    }

    public class NumericRule : Rule
    {
        private const string info = "数字を入力してください";

        public NumericRule() : base() { }

        protected override bool CanApply(RuleRequest request)
        {
            return !int.TryParse(request.Guess, out int _);
        }

        protected override RuleResponse MakeRuleResponse(RuleRequest request)
        {
            return new RuleResponse(info);
        }
    }

    public class DigitsRule : Rule
    {
        public DigitsRule() : base() { }        

        protected override bool CanApply(RuleRequest request)
        {
            return request.Secret.Length != request.Guess.Length;
        }

        protected override RuleResponse MakeRuleResponse(RuleRequest request)
        {
            string info = $"シークレットは{request.Secret.Length}桁です";
            return new RuleResponse(info);
        }
    }

    public class MatchRule : Rule
    {

        string info = "Bingo!!!";

        public MatchRule() : base() { }

        protected override bool CanApply(RuleRequest request)
        {
            return request.Secret.Equals(request.Guess);
        }

        protected override RuleResponse MakeRuleResponse(RuleRequest request)
        {
            info = $"Bingo!!! 正解は {request.Secret} でした。\r\n";
            var response = new RuleResponse(info);
            response.Cleared = true;

            return response;
        }
    }

    public class GameRule : Rule
    {
        public GameRule() : base() { }

        protected override bool CanApply(RuleRequest request)
        {
            return true;
        }

        protected override RuleResponse MakeRuleResponse(RuleRequest request)
        {
            int bulls = 0, cows = 0;
            int[] count = new int[10];

            for (int i = 0; i < request.Secret.Length; i++)
            {
                if (request.Secret[i] == request.Guess[i]) bulls++;
                else
                {
                    if (count[request.Secret[i] - '0']++ < 0) cows++;
                    if (count[request.Guess[i] - '0']-- > 0) cows++;
                }
            }
            
            return new RuleResponse($"{bulls}A{cows}B");
        }
    }

}
