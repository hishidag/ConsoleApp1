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

                if(!int.TryParse(guess, out int _))
                {
                    Console.WriteLine("数字を入力してください");
                    continue;
                }

                if (secret.Length != guess.Length)
                {
                    Console.WriteLine($"シークレットは{secret.Length}桁です");
                    continue;
                }

                if (secret.Equals(guess))
                {
                    Console.WriteLine("Bingo!!!");
                    continue;
                }

                int bulls = 0, cows = 0;
                int[] count = new int[10];

                for (int i = 0; i < secret.Length; i++)
                {
                    if (secret[i] == guess[i]) bulls++;
                    else
                    {
                        if (count[secret[i] - '0']++ < 0) cows++;
                        if (count[guess[i] - '0']-- > 0) cows++;
                    }
                }

                Console.WriteLine($"{bulls}A{cows}B");
            }

        }
    }
}

