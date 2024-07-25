using Microsoft.Data.Sqlite;
using System.Data.SQLite;
using System.Globalization;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HabitLogger;
public static class DBHelper
{
    private static string connectionString = @"Data Source = ..\..\..\Files\habitlogger.db;Version=3;";

    public static void InitializeDatabase() 
    {
        if (!File.Exists(@"..\..\..\Files\habitlogger.db"))
        {
            SQLiteConnection.CreateFile(@"..\..\..\Files\habitlogger.db");

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string createDrinkingWaterTableQuery = @" 
                    CREATE TABLE IF NOT EXISTS drinking_water (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Date TEXT,
                            Quantity INTEGER
                    );";

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = createDrinkingWaterTableQuery;
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                
            }
        }
    }

    public static void InsertRecord(string date, int quantity)
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string insertIntoDrinkingWaterTableQuery = $"INSERT INTO drinking_water (date, quantity) VALUES('{date}', {quantity})";

            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText = insertIntoDrinkingWaterTableQuery;
                command.ExecuteNonQuery();
                connection.Close();
            }

        }
    }

    public static List<DrinkingWater> GetAllRecords()
    {
        List<DrinkingWater> tableData = new();

        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            var tableCmd = connection.CreateCommand();
            tableCmd.CommandText = "SELECT * FROM drinking_water";

            using (SQLiteDataReader reader = tableCmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tableData.Add(new DrinkingWater
                        {
                            Id = reader.GetInt32(0),
                            Date = DateTime.ParseExact(reader.GetString(1), "dd-MM-yy", new CultureInfo("en-US")),
                            Quantity = reader.GetInt32(2)
                        });
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
            }

            connection.Close();
        }

        return tableData;
    }

    internal static int DeleteRecord(int recordId)
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string  deleteFromDrinkingWater = $"DELETE FROM drinking_water WHERE Id = {recordId}";

            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText = deleteFromDrinkingWater;
                int rowCount = command.ExecuteNonQuery();
                connection.Close();
                return rowCount;
            }
        }
    }

    internal static int CheckIfRecordExists(int recordId)
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            var checkCmd = connection.CreateCommand();
            checkCmd.CommandText = $"SELECT EXISTS(SELECT 1 FROM drinking_water WHERE Id = {recordId})";
            int checkQuery = Convert.ToInt32(checkCmd.ExecuteScalar());
            connection.Close();
            return checkQuery;
        }
    }

    internal static void UpdateRecord(int recordId, string date, int quantity)
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            var tableCmd = connection.CreateCommand();
            tableCmd.CommandText = $"UPDATE drinking_water SET date = '{date}', quantity = {quantity} WHERE Id = {recordId}";
            tableCmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}

public class DrinkingWater
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int Quantity { get; set; }
}