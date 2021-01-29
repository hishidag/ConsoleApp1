using System;
using System.Collections.Generic;
using System.Linq;

namespace BullsAndCowsGame
{
    abstract class Secret
    {
        public abstract int OfferSecretNumber();
    }

    class OfferFixedValue : Secret
    {
        public override int OfferSecretNumber()
        {
            return 1234;
        }
    }

    class OfferRandomValue : Secret
    {
        public override int OfferSecretNumber()
        {
            return new Random().Next(0, (int)Math.Pow(10, 4));
        }
    }

    class OfferRandomDistinctValue : Secret
    {
        public override int OfferSecretNumber()
        {
            int num = 0;
            List<int> numlist = Enumerable.Range(0, 10).ToList();
            
            while (numlist.Count > 1)
            {
                int takeIndex = new Random().Next(0, numlist.Count);
                num = 10 * num + numlist[takeIndex];
                numlist.RemoveAt(takeIndex);
            }

            return num;
        }
    }


}
