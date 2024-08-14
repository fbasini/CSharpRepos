using System.Globalization;

namespace HabitLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            DBHelper.InitializeDatabase();
            GetUserInput();
        }

        static void GetUserInput()
        {
            Console.Clear();
            bool closeApp = false;
            while (closeApp == false)
            {
                Console.WriteLine("\n\nMAIN MENU");
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("\nType 0 to Close Application.");
                Console.WriteLine("Type 1 to View All Records.");
                Console.WriteLine("Type 2 to Insert a Record.");
                Console.WriteLine("Type 3 to Update a Record.");
                Console.WriteLine("Type 4 to Delete a Record.");
                Console.WriteLine("----------------------------------\n");

                string? userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "0":
                        Console.WriteLine("\nGoodbye!\n");
                        closeApp = true;
                        Environment.Exit(0);
                        break;
                    case "1":
                        GetAllRecords();
                        break;
                    case "2":
                        InsertRecord();
                        break;
                    case "3":
                        UpdateRecord();
                        break;
                    case "4":
                        DeleteRecord();
                        break;
                    default:
                        Console.WriteLine("\nInvalid input. Please try again.\n");
                        break;
                }
            }
        }

        private static void UpdateRecord()
        {
            Console.Clear();
            GetAllRecords();

            var recordId = GetNumberInput("\n\nPlease type the ID of the record you want to update or type 0 to go back to main menu.\n\n");

            int checkQuery = DBHelper.CheckIfRecordExists(recordId);

            if (checkQuery == 0)
            {
                Console.WriteLine($"\n\nRecord with Id {recordId} doesn't exist.\n\n");
                UpdateRecord();
            }
            else
            {
                string date = GetDateInput();
                int quantity = GetNumberInput("\n\nPlease insert number of glasses or other measure of your choice (no decimals allowed)\n\n");
                DBHelper.UpdateRecord(recordId, date, quantity);
                Console.WriteLine($"\n\nRecord with Id {recordId} was updated.\n\n");
            }

            GetUserInput();
        }

        private static void DeleteRecord()
        {
            Console.Clear();
            GetAllRecords();

            var recordId = GetNumberInput("\n\nPlease type the ID of the record you want to delete or type 0 to go back to main menu.\n\n");

            int rowCount = DBHelper.DeleteRecord(recordId);

            if (rowCount == 0)
            {
                Console.WriteLine($"\n\n No record found with ID {recordId}.");
                DeleteRecord();
            }

            Console.WriteLine($"\n\nRecord with Id {recordId} was deleted. \n\n");

            GetUserInput();
        }

        private static void GetAllRecords()
        {
            Console.Clear();
            List<DrinkingWater> tableData = DBHelper.GetAllRecords();

            Console.WriteLine("----------------------------------\n");
            foreach (var dw in tableData)
            {
                Console.WriteLine($"{dw.Id} - {dw.Date.ToString("dd-MM-yyyy")} - Quantity: {dw.Quantity}");
            }
            Console.WriteLine("----------------------------------\n");
        }

        private static void InsertRecord()
        {
            string date = GetDateInput();

            int quantity = GetNumberInput("\n\nPlease insert number of glasses or other measure of your choice (no decimals)\n\n");

            DBHelper.InsertRecord(date, quantity);
        }

        internal static int GetNumberInput(string message)
        {
            Console.WriteLine(message);
            string numberInput = Console.ReadLine();

            if (numberInput == "0") GetUserInput();

            while (!Int32.TryParse(numberInput, out _) || Convert.ToInt32(numberInput) < 0)
            {
                Console.WriteLine("\n\nInvalid input. Please try again.\n\n");
                numberInput = Console.ReadLine();
            }

            int finalInput = Convert.ToInt32(numberInput);

            return finalInput;
        }

        internal static string GetDateInput()
        {
            Console.WriteLine("\n\nPlease insert the date: (Format: dd-mm-yy). Type 0 to return to main menu.\n\n");
            string dateInput = Console.ReadLine();

            if (dateInput == "0") GetUserInput();

            while(!DateTime.TryParseExact(dateInput, "dd-MM-yy", new CultureInfo("en-US"), DateTimeStyles.None, out _))
            {
                Console.WriteLine("\n\nInvalid date format. Please try again.\n\n");
                dateInput = Console.ReadLine();
            }

            return dateInput;
        }
    }
}
