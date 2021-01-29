using System;
using System.Collections.Generic;
using System.Linq;

namespace BullsAndCowsGame
{
    public class Game
    {
        private readonly Rule rules = RuleBuilder.GetRule();

        private readonly OfferSecret offer;

        public Game(int gameType = 0, int digits = 4)
        {
            this.offer = new OfferSecret();
            ChangeGameType(gameType);
            ChangeDigits(digits);
            Start();
        }

        /// <summary>
        /// 現在の設定で新しいゲームを開始する
        /// </summary>
        public void Start()
        {
            offer.ChangeSecret();
        }

        /// <summary>
        /// 推測された値への結果を返す
        /// </summary>
        /// <returns>
        /// （結果、完全に一致したか）
        /// </returns>
        public (string, bool) Guess(string guess)
        {
            RuleResponse response = rules.Apply(new RuleRequest(offer.Secret, guess));
            return (response.Info ?? "", response.Cleared);
        }

        /// <summary>
        /// ゲームの種類を変更する。
        /// </summary>
        public void ChangeGameType(int gameType)
        {
            offer.ChangeStrategy(gameType);
        }

        /// <summary>
        /// ゲームの桁数を変更する。
        /// </summary>
        public void ChangeDigits(int digits)
        {
            offer.Digits = digits;
        }

    }
}
