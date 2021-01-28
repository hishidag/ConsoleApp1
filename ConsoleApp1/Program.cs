using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool canceled = false;

            Console.CancelKeyPress += new ConsoleCancelEventHandler((obj, args) => 
            {
                canceled = true;
                args.Cancel = true;
            });
            
            var game = new Game();

            while (!canceled)
            {
                var input = Console.ReadLine();
                Console.WriteLine(game.Guess(input));
            }

            Console.WriteLine("キー入力で終了");

            Console.ReadLine();
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

