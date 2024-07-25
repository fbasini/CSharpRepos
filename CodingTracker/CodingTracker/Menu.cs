using static CodingTracker.Helpers;
using static CodingTracker.DAO.Database;
using Spectre.Console;

namespace CodingTracker
{
    public static class Menu
    {
        public static void ShowMenu()
        {
            bool closeApp = false;
            while (closeApp == false)
            {
                AnsiConsole.Clear();
                Console.WriteLine("\n\nMAIN MENU");
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("\nType 0 to Close Application.");
                Console.WriteLine("Type 1 to View your coding sessions history.");
                Console.WriteLine("Type 2 to Add a coding session.");
                Console.WriteLine("Type 3 to Delete a session history.");
                Console.WriteLine("Type 4 to Update a session history.");
                Console.WriteLine("----------------------------------\n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "0":
                        Console.WriteLine("\nGoodbye!\n");
                        closeApp = true;
                        Environment.Exit(0);
                        break;
                    case "1":
                        Console.Clear();
                        DisplaySessions(GetSessionsHistory());
                        Console.WriteLine("\nPress Enter to go back to the menu");
                        Console.ReadLine();
                        break;
                    case "2":
                        AnsiConsole.Clear();
                        string result = InsertSession();
                        if (result == "1")
                        {
                            Console.WriteLine("\nSession added successfully!\n");
                            Console.WriteLine("\nPress Enter to go back to the menu");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("\nFailed to add session.\n");
                            Console.WriteLine("\nPress Enter to go back to the menu");
                            Console.ReadLine();
                        }
                        break;
                    case "3":
                        AnsiConsole.Clear();
                        DisplaySessions(GetSessionsHistory());
                        Console.WriteLine("\nEnter the ID of the session you want to delete:");
                        int idToDelete = GetNumberInput("");
                        int rowsDeleted = DeleteCodingSession(idToDelete);
                        if (rowsDeleted > 0)
                        {
                            Console.WriteLine("\nSession deleted successfully!\n");
                            Console.WriteLine("\nPress Enter to go back to the menu");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("\nFailed to delete session.\n");
                            Console.WriteLine("\nPress Enter to go back to the menu");
                            Console.ReadLine();
                        }
                        break;
                    case "4":
                        AnsiConsole.Clear();
                        DisplaySessions(GetSessionsHistory());
                        Console.WriteLine("\nEnter the ID of the session you want to update:");
                        int idToUpdate = GetNumberInput("");
                        int updateResult = UpdateSession(idToUpdate);
                        if (updateResult == 1)
                        {
                            Console.WriteLine("\nSession updated successfully!\n");
                            Console.WriteLine("\nPress Enter to go back to the menu");
                            Console.ReadLine();
                        }
                        else if (updateResult == 0)
                        {
                            Console.WriteLine("\nSession ID not found.\n");
                            Console.WriteLine("\nPress Enter to go back to the menu");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("\nFailed to update session.\n");
                            Console.WriteLine("\nPress Enter to go back to the menu");
                            Console.ReadLine();
                        }
                        break;
                    default:
                        Console.WriteLine("\nInvalid input. Please try again.\n");
                        break;
                }
            }
        }
    }
}
