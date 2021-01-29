using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using BullsAndCowsGame;

namespace UnitTestProject1
{
    [TestClass]
    public class TestSecretStrategy
    {
        [TestMethod]
        public void TestFixedSecret()
        {
            OfferSecret.ChangeStrategy(GameStrategy.Fixed);
            Assert.AreEqual("1234", OfferSecret.Secret);
        }

        [TestMethod]
        public void TestRandomSecret()
        {
            OfferSecret.ChangeStrategy(GameStrategy.Random);
            for (int i = 0; i < 10; i++)
            {
                var left = OfferSecret.Secret;
                var right = OfferSecret.Secret;
                System.Diagnostics.Debug.WriteLine("{0} : {1}", left, right);
                Assert.AreNotEqual(OfferSecret.Secret, OfferSecret.Secret);
            }
        }

        [TestMethod]
        public void TestDistinctSecret()
        {
            OfferSecret.ChangeStrategy(GameStrategy.Distinct);
            Assert.AreNotEqual(OfferSecret.Secret, OfferSecret.Secret);

            for (int i = 0; i < 10; i++)
            {
                var test = OfferSecret.Secret;
                System.Diagnostics.Debug.WriteLine(test);

                string res = "";

                Assert.AreEqual(test.Distinct().Aggregate(res, (l, r) => l += r), test);

            }
        }


    }
}
