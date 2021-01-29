using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using BullsAndCowsGame;

namespace UnitTestProject1
{
    [TestClass]
    public class TestOfferSecret
    {
        OfferSecret offer = new OfferSecret();

        [TestInitialize]
        public void TestInitialize()
        {
            offer.ChangeStrategy((int)GameType.Fixed);
            offer.Digits = 4;
            offer.ChangeSecret();
        }

        [TestMethod]
        public void TestFixedSecret()
        {
            offer.ChangeStrategy((int)GameType.Fixed);

            offer.ChangeSecret();
            Assert.AreEqual("1234", offer.Secret);
        }

        [TestMethod]
        public void TestRandomSecret()
        {
            offer.ChangeStrategy((int)GameType.Random);
            for (int i = 0; i < 10; i++)
            {
                offer.ChangeSecret();
                var left = offer.Secret;

                offer.ChangeSecret();
                var right = offer.Secret;

                System.Diagnostics.Debug.WriteLine("{0} : {1}", left, right);
                Assert.AreNotEqual(left, right);
            }
        }

        [TestMethod]
        public void TestDistinctSecret()
        {
            offer.ChangeStrategy((int)GameType.Distinct);

            offer.ChangeSecret();
            var left = offer.Secret;

            offer.ChangeSecret();
            var right = offer.Secret;

            Assert.AreNotEqual(left, right);

            for (int i = 0; i < 10; i++)
            {
                offer.ChangeSecret();
                var test = offer.Secret;
                System.Diagnostics.Debug.WriteLine(test);

                string res = "";

                Assert.AreEqual(test.Distinct().Aggregate(res, (l, r) => l += r), test);

            }
        }

        [TestMethod]
        public void TestNotSuchGameType()
        {            
            Assert.ThrowsException<Exception>(() => offer.ChangeStrategy(-1));
            Assert.ThrowsException<Exception>(() => offer.ChangeStrategy(3));
        }


    }
}
