using CodingTracker.Models;
using Spectre.Console;
using System.Globalization;

namespace CodingTracker
{
    public static class Helpers
    {
        public static string InputSessionDate()
        {
            Console.WriteLine("\n\nPlease insert the date: (Format: dd-mm-yy). Type 0 to return to main menu.\n\n");
            string dateInput = Console.ReadLine();

            while (!DateTime.TryParseExact(dateInput, "dd-MM-yy", new CultureInfo("en-US"), DateTimeStyles.None, out _))
            {
                Console.WriteLine("\n\nInvalid date format. Please try again.\n\n");
                dateInput = Console.ReadLine();
            }

            return dateInput;
        }

        public static (DateTime startTime, DateTime endTime) InputSessionTime()
        {
            Console.WriteLine("\n\nPlease insert the start time: (Format: HH:mm). Type 0 to return to main menu.\n\n");
            string startTimeInput = Console.ReadLine();
            DateTime startTime;

            while (!DateTime.TryParseExact(startTimeInput, "HH:mm", new CultureInfo("en-US"), DateTimeStyles.None, out startTime))
            {
                Console.WriteLine("\n\nInvalid time format. Please try again.\n\n");
                startTimeInput = Console.ReadLine();
            }

            if (startTimeInput == "0") return (default, default);

            Console.WriteLine("\n\nPlease insert the end time: (Format: HH:mm). Type 0 to return to main menu.\n\n");
            string endTimeInput = Console.ReadLine();
            DateTime endTime;

            while (!DateTime.TryParseExact(endTimeInput, "HH:mm", new CultureInfo("en-US"), DateTimeStyles.None, out endTime))
            {
                Console.WriteLine("\n\nInvalid time format. Please try again.\n\n");
                endTimeInput = Console.ReadLine();
            }

            if (endTimeInput == "0") return (default, default);

            return (startTime, endTime);
        }

        public static int GetNumberInput(string message)
        {
            Console.WriteLine(message);
            string numberInput = Console.ReadLine();

            while (!Int32.TryParse(numberInput, out _) || Convert.ToInt32(numberInput) < 0)
            {
                Console.WriteLine("\n\nInvalid input. Please try again.\n\n");
                numberInput = Console.ReadLine();
            }

            int finalInput = Convert.ToInt32(numberInput);

            return finalInput;
        }

        public static void DisplaySessions(List<CodingSessions> codingSessions)
        {
            Console.Clear();

            DisplayTitle("List of all sessions");

            // Create a table
            var table = new Table();

            // Add some columns
            table.AddColumn("ID");
            table.AddColumn("Date");
            table.AddColumn("Start Time");
            table.AddColumn("End Time");
            table.AddColumn("Duration");

            // Add coding session list
            foreach (var session in codingSessions)
            {
                table.AddRow(
                    session.Id.ToString(),
                    session.Date.ToString("dd-MM-yy"),
                    session.StartTime.ToString("HH:mm"),
                    session.EndTime.ToString("HH:mm"),
                    session.GetFormattedDuration());
            }
            

            // Render the table to the console
            AnsiConsole.Write(table);
        }

        public static void DisplayTitle(string title)
        {
            var rule = new Rule("[blue]" + title + "[/]");
            rule.LeftJustified();
            AnsiConsole.Write(rule);
        }

    }
}
