using System;
using System.Diagnostics.Contracts;

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

    public class RuleResponse
    {
        private string _info;

        public string Info { 
            get
            {
                Contract.Requires<NotSetInfoException>(_info != null, "レスポンスが処理されていません。");
                return _info; 
            }
            private set => _info = value ; 
        }

        public RuleResponse(string info)
        {
            Info = info;
        }
    }

    public class NotSetInfoException : Exception
    {
        public NotSetInfoException() { }

        public NotSetInfoException(string message) : base(message) { }

        public NotSetInfoException(string message, Exception inner) : base(message, inner) { }

        protected NotSetInfoException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }


    // Chain of Responsibility
    abstract class Rule
    {
        private Rule nextRule;
        protected string info;

        public Rule() { }

        abstract protected bool CanApply(RuleRequest request);

        public Rule ChainRule(Rule next)
        {
            this.nextRule = next;
            return next;
        }

        public RuleResponse Apply(RuleRequest request)
        {
            if (CanApply(request)) return new RuleResponse(info);
            return nextRule?.Apply(request);
        }

    }

    class NumericRule : Rule
    {
        public NumericRule() : base()
        {
            base.info = "数字を入力してください";
        }

        protected override bool CanApply(RuleRequest request)
        {
            return !int.TryParse(request.Guess, out int _);
        }
    }

    class DigitsRule : Rule
    {
        public DigitsRule() : base() { }

        protected override bool CanApply(RuleRequest request)
        {
            base.info = $"シークレットは{request.Secret.Length}桁です";
            return request.Secret.Length != request.Guess.Length;
        }
    }

    class MatchRule : Rule
    {
        public MatchRule() : base() 
        {
            base.info = "Bingo!!!";
        }

        protected override bool CanApply(RuleRequest request)
        {
            return request.Secret.Equals(request.Guess);
        }

    }

    class GameRule : Rule
    {
        public GameRule() : base() { }

        protected override bool CanApply(RuleRequest request)
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

            base.info = $"{bulls}A{cows}B";

            return true;
        }
    }

}
