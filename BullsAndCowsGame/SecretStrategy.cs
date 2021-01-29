using System;
using System.Collections.Generic;
using System.Linq;

namespace BullsAndCowsGame
{
    abstract class SecretStrategy
    {
        public abstract int OfferSecretNumber(Digits digits);
    }

    class OfferFixedValue : SecretStrategy
    {
        public override int OfferSecretNumber(Digits _)
        {
            return 1234;
        }
    }

    class OfferRandomValue : SecretStrategy
    {
        public override int OfferSecretNumber(Digits digits)
        {
            return new Random().Next(0, (int)Math.Pow(10, digits.Value));
        }
    }

    class OfferRandomDistinctValue : SecretStrategy
    {
        public override int OfferSecretNumber(Digits digits)
        {
            if (digits.Value > 10) 
                throw new CannotOfferException("数字を重複させない場合、10桁以内である必要があります。");

            int num = 0;
            List<int> numlist = Enumerable.Range(0, 10).ToList();

            for (int i = 0; i < digits.Value; i++)
            {
                int takeIndex = new Random().Next(0, numlist.Count);
                num = 10 * num + numlist[takeIndex];
                numlist.RemoveAt(takeIndex);
            }

            return num;
        }
    }
}
