using System;

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

                Rule rules = RuleBuilder.GetRule();

                RuleResponse err = rules.Apply(new RuleRequest(secret, guess));
                if(!string.IsNullOrEmpty(err.Info))
                {
                    Console.WriteLine(err.Info);
                    continue;
                }

            }

        }
    }
}

