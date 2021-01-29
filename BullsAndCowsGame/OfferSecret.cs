namespace BullsAndCowsGame
{
    public static class OfferSecret
    {
        private static Secret Strategy = new OfferFixedValue();

        private static readonly Secret[] Strategies = 
            { new OfferFixedValue(), new OfferRandomValue(), new OfferRandomDistinctValue() };

        public static string Secret 
        {
            get => Strategy.OfferSecretNumber().ToString().PadLeft(4, '0');
        }

        public static void ChangeStrategy(GameStrategy strategy)
        {
            Strategy = Strategies[(int)strategy];
        }

    }


}
