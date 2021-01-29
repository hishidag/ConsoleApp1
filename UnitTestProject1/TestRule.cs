using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BullsAndCowsGame;

namespace UnitTestProject1
{
    [TestClass]
    public class TestRule
    {
        Func<string, Func<string, RuleRequest>> func = (secret) => (guess) => new RuleRequest(secret, guess);
        Func<string, RuleRequest> fixedSecret;

        const string checkString = "dummy";
        const string fixedSecretNo = "1234";


        class DummyRule : Rule
        {
            protected override bool CanApply(RuleRequest request)
            {
                return true;
            }

            protected override RuleResponse MakeRuleResponse(RuleRequest request)
            {
                return new RuleResponse(checkString);
            }
        }

        class LastRule : Rule
        {
            protected override bool CanApply(RuleRequest request)
            {
                return false;
            }

            protected override RuleResponse MakeRuleResponse(RuleRequest request)
            {
                return new RuleResponse(checkString);
            }

        }

        [TestInitialize]
        public void TestInitalize()
        {
            fixedSecret = func(fixedSecretNo);
        }

        [TestMethod]
        public void TestAbstractRule()
        {
            Rule rule1 = new DummyRule();
            Assert.AreEqual(checkString, rule1.Apply(fixedSecret("")).Info);

            Rule rule2 = new LastRule();
            Assert.ThrowsException<NotImplementedException>(() => rule2.Apply(fixedSecret("")).Info);

            Rule rule3 = rule1.ChainRule(rule2);
            Assert.AreEqual(checkString, rule1.Apply(fixedSecret("")).Info);

            Rule rule4 = rule2.ChainRule(rule1);
            Assert.AreEqual(checkString, rule1.Apply(fixedSecret("")).Info);

        }

        [TestMethod]
        public void TestNumericRule()
        {
            Rule rule = new NumericRule();

            var res = rule.Apply(fixedSecret("aaaa"));
            Assert.IsFalse(string.IsNullOrEmpty(res.Info));

        }

        [TestMethod]
        public void TestDigitsRule()
        {
            Rule rule = new DigitsRule();

            var res = rule.Apply(fixedSecret("1"));
            Assert.IsFalse(string.IsNullOrEmpty(res.Info));
        }

        [TestMethod]
        public void TestMatchRule()
        {
            Rule rule = new MatchRule();

            var res = rule.Apply(fixedSecret(fixedSecretNo));
            Assert.AreEqual($"Bingo!!! ê≥âÇÕ {fixedSecretNo} Ç≈ÇµÇΩÅB\r\n", res.Info);
        }

        [TestMethod]
        public void TestGameRule()
        {
            Rule rule = new GameRule();

            var res = rule.Apply(fixedSecret(fixedSecretNo));
            Assert.AreEqual(res.Info,"4A0B");

            res = rule.Apply(fixedSecret("4321"));
            Assert.AreEqual(res.Info, "0A4B");

            res = rule.Apply(fixedSecret("7890"));
            Assert.AreEqual(res.Info, "0A0B");

        }


    }
}
