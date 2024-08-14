using MathGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MathGame
{
    internal class Helpers
    {
        static List<Game> games = new List<Game>
        {
            //new Game { Date = DateTime.Now.AddDays(1), Score = 5, Type = GameType.Addition },
            //new Game { Date = DateTime.Now.AddDays(2), Score = 2, Type = GameType.Multiplication },
            //new Game { Date = DateTime.Now.AddDays(3), Score = 6, Type = GameType.Division },
            //new Game { Date = DateTime.Now.AddDays(4), Score = 4, Type = GameType.Addition },
            //new Game { Date = DateTime.Now.AddDays(5), Score = 5, Type = GameType.Subtraction },
            //new Game { Date = DateTime.Now.AddDays(6), Score = 6, Type = GameType.Subtraction },
            //new Game { Date = DateTime.Now.AddDays(7), Score = 7, Type = GameType.Addition },
            //new Game { Date = DateTime.Now.AddDays(8), Score = 8, Type = GameType.Division },
            //new Game { Date = DateTime.Now.AddDays(9), Score = 9, Type = GameType.Division },
            //new Game { Date = DateTime.Now.AddDays(10), Score = 1, Type = GameType.Multiplication },
            //new Game { Date = DateTime.Now.AddDays(11), Score = 11, Type = GameType.Addition },
            //new Game { Date = DateTime.Now.AddDays(12), Score = 10, Type = GameType.Multiplication },
            //new Game { Date = DateTime.Now.AddDays(13), Score = 3, Type = GameType.Subtraction },
            //new Game { Date = DateTime.Now.AddDays(14), Score = 4, Type = GameType.Subtraction },
            //new Game { Date = DateTime.Now.AddDays(15), Score = 5, Type = GameType.Addition },
        };

        internal static void PrintGames()
        {
            //LINQ
            //var gamesToPrint = games.Where(x => x.Type == GameType.Addition).OrderByDescending(x => x.Score);

            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("--------------------");
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Type}: {game.Score}pts");
            }
            Console.WriteLine("--------------------\n");
            Console.WriteLine("Press any key to go back to the main menu.");
            Console.ReadLine();
        }

        internal static void AddToHistory(int gameScore, GameType gameType)
        {
            games.Add(new Game 
            { 
                Date = DateTime.Now, 
                Score = gameScore,
                Type = gameType 
            });
        }

        internal static int[] GetDivisionNumbers()
        {
            var random = new Random();
            var firstNumber = random.Next(1, 99);
            var secondNumber = random.Next(1, 99);

            var result = new int[2];

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(1, 99);
                secondNumber = random.Next(1, 99);
            }

            result[0] = firstNumber;
            result[1] = secondNumber;

            return result;
        }

        internal static string? ValidateResult(string result)
        {
            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            { 
                Console.WriteLine("You must enter a valid number. Try again.");  
                result = Console.ReadLine();
            }

            return result;
        }

        internal static string GetName()
        {
            Console.WriteLine("Enter your name: ");
            var name = Console.ReadLine();

            while(string.IsNullOrEmpty(name))
            {
                Console.WriteLine("You must enter a name. Try again.");
                name = Console.ReadLine();
            }

            return name;
        }
    }
}
