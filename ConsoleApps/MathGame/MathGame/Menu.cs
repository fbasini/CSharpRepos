namespace MathGame
{
    internal class Menu
    {
        GameEngine gameEngine = new();

        internal void ShowMenu(string name, DateTime date)
        {
            var isGameOn = true;

            do
            {
                Console.Clear();
                Console.WriteLine("--------------------");
                Console.WriteLine($"Hello, {name.ToUpper()}. It's {date}. Welcome to your Math Game. \n");
                Console.WriteLine($@"Choose from the following options: 
0. View previous games
1. Addition
2. Subtraction
3. Multiplication
4. Division
5. Exit");
                Console.WriteLine("--------------------");

                var option = Console.ReadLine();

                switch (option.Trim().ToLower())
                {
                    case "0":
                        Helpers.PrintGames();
                        break;
                    case "1":
                        gameEngine.AdditionGame("Addition game");
                        break;
                    case "2":
                        gameEngine.SubtractionGame("Subtraction game");
                        break;
                    case "3":
                        gameEngine.MultiplicationGame("Multiplication game");
                        break;
                    case "4":
                        gameEngine.DivisionGame("Division game");
                        break;
                    case "5":
                        Console.WriteLine("Goodbye!");
                        isGameOn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            } while (isGameOn);
        }
    }
}
