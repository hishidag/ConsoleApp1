using System;

namespace BullsAndCowsGame
{
    public class OfferSecret
    {
        private SecretStrategy Strategy;

        private Digits _digits;

        /// <summary>
        /// ゲームの桁数
        /// </summary>
        /// <exception cref="IllegalDigitsException"></exception>
        public int Digits
        {
            get => _digits.Value;
            set => _digits = new Digits(value);
        }

        public string Secret { get; private set; }

        private static readonly SecretStrategy[] Strategies = 
            { new OfferFixedValue(), new OfferRandomValue(), new OfferRandomDistinctValue() };

        public OfferSecret(int type = 0, int digits = 4)
        {
            ChangeStrategy(type);
            Digits = digits;
            Secret = Strategy.OfferSecretNumber(_digits).ToString().PadLeft(4, '0');
        }

        public void ChangeSecret()
        {
            Secret = Strategy.OfferSecretNumber(_digits).ToString().PadLeft(_digits.Value, '0');
        }

        public void ChangeStrategy(int gameType)
        {
            //TODO
            if (gameType < 0 || gameType >= Strategies.Length) 
                throw new Exception("ゲームタイプ指定エラー");

            Strategy = Strategies[gameType];
        }

    }


}
