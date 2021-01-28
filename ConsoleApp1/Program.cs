using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool canceled = false;

            Console.WriteLine("ようこそ");

            var game = new Game();

            while (!canceled)
            {                
                var input = Console.ReadLine();

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

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

