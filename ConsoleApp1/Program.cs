using System;
using BullsAndCows;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler((obj, args) =>
            {
                // Ctrl + C でエレガントにプログラムを終了させる
                args.Cancel = true;
            });

            Console.WriteLine("ようこそ");

            var game = new Game();

            while (true)
            {                
                var input = Console.ReadLine();

                // Ctrl + C のとき null が入力された扱いになる
                if (input is null) break;

                var result = game.Guess(input);
                Console.WriteLine(result.Item1);
                
                if (result.Item2) 
                {
                    Console.WriteLine("yを押下すると新しいゲームを開始します。");
                    if ("y".Equals(Console.ReadLine()))
                    {
                        game.Start();
                        Console.WriteLine("ようこそ");
                    }
                    else
                    {
                        break;
                    }
                };
            }

            Console.WriteLine("キー入力で終了");

            Console.ReadKey();
        }

    }
}

