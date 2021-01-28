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

                Rule numrule = new NumericRule(new DigitsRule(new MatchRule(new GameRule(null))));
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

