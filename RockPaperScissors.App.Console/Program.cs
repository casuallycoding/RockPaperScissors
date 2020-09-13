using RockPaperScissors.Core.Objects;
using System;

namespace RockPaperScissors.App.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {


            Paper paper = new Paper("");
            Rock rock = new Rock("");
            Scissors scissors = new Scissors("");

            Console.WriteLine(paper.GetResult(scissors)); // Paper vs scissors - loss
            Console.WriteLine(paper.GetResult(rock)); // Paper vs rock - win
            Console.WriteLine(paper.GetResult(paper)); // Paper vs Paper - draw


            RockPaperScissorsGame game = new RockPaperScissorsGame();
            var firstPick = game.GetRandomElement();
            var secondPick = game.GetRandomElement();

            Console.WriteLine($"{firstPick.GetType().Name} vs {secondPick.GetType().Name}  = {firstPick.GetResult(secondPick)}");


        }
    }
}
