using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string secret = "1234";

            while (true)
            {
                string guess = Console.ReadLine();

                Rule numrule = new NumericRule().ChainRule(new DigitsRule())
                                                .ChainRule(new MatchRule())
                                                .ChainRule(new GameRule());

                string err = numrule.Apply(secret, guess);
                if(!string.IsNullOrEmpty(err))
                {
                    Console.WriteLine(err);
                    continue;
                }

            }

        }
    }
}

