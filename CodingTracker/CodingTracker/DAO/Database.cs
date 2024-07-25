using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Data.SQLite;
using CodingTracker.Models;
using System.Globalization;
using static CodingTracker.Helpers;

namespace CodingTracker.DAO
{
    public static class Database
    {
        private static string connectionString = ConfigurationManager.AppSettings.Get("connectionString");

        public static void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS CodingSessions (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                        Date TEXT NOT NULL, 
                        StartTime TEXT NOT NULL,
                        EndTime TEXT NOT NULL,
                        TimeSpentCoding TEXT NOT NULL
                )";

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = createTableQuery;
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public static string InsertSession()
        {
            string operationComplete = "0";

            string date = InputSessionDate();

            if (date == "0") return operationComplete;

            var (startTime, endTime) = InputSessionTime();

            if (startTime == default && endTime == default) return operationComplete;

            var session = new CodingSessions { StartTime = startTime, EndTime = endTime };
            string timeSpentCoding = session.GetFormattedDuration();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                SQLiteCommand tableCommand = connection.CreateCommand();

                tableCommand.CommandText =
                    $@"INSERT INTO CodingSessions(Date, StartTime, EndTime, TimeSpentCoding) 
                        VALUES('{date}', '{startTime:HH:mm}', '{endTime:HH:mm}', '{timeSpentCoding}')";

                tableCommand.ExecuteNonQuery();

                operationComplete = "1";

                connection.Close();
            }

            return operationComplete;
        }

        public static int DeleteCodingSession(int id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string deleteQuery = $@"DELETE FROM CodingSessions WHERE Id = {id}";

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = deleteQuery;
                    int rowCont = command.ExecuteNonQuery();
                    connection.Close();
                    return rowCont;
                }
            }
        }

        public static int UpdateSession(int id)
        {
            int checkQuery = 0;
            if (id != 0)
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    var checkCommand = connection.CreateCommand();
                    checkCommand.CommandText = $"SELECT EXISTS(SELECT 1 FROM CodingSessions WHERE Id = {id})";

                    SQLiteCommand tableCommand = connection.CreateCommand();
                    checkQuery = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (checkQuery == 0) return checkQuery;

                    string date = InputSessionDate();
                    if (date == "0") return 2;

                    var (startTime, endTime) = InputSessionTime();
                    if (startTime == default && endTime == default) return 2;

                    var session = new CodingSessions { StartTime = startTime, EndTime = endTime };
                    string timeSpentCoding = session.GetFormattedDuration();

                    tableCommand.CommandText =
                        $@"UPDATE CodingSessions 
                           SET Date = '{date}', StartTime = '{startTime:HH:mm}', EndTime = '{endTime:HH:mm}', TimeSpentCoding = '{timeSpentCoding}' 
                           WHERE Id = {id}";

                    tableCommand.ExecuteNonQuery();

                    connection.Close();
                }
            }
            return checkQuery;
        }

        public static List<CodingSessions> GetSessionsHistory()
        {
            List<CodingSessions> tableData = new();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = "SELECT * FROM CodingSessions";

                using (SQLiteDataReader reader = tableCmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            tableData.Add(new CodingSessions
                            {
                                Id = reader.GetInt32(0),
                                Date = DateTime.ParseExact(reader.GetString(1), "dd-MM-yy", CultureInfo.InvariantCulture),
                                StartTime = DateTime.ParseExact(reader.GetString(2), "HH:mm", CultureInfo.InvariantCulture),
                                EndTime = DateTime.ParseExact(reader.GetString(3), "HH:mm", CultureInfo.InvariantCulture),
                            });
                        }
                    }
                    else
                    {
                        Console.WriteLine("No session found.");
                    }
                }

                connection.Close();
            }

            return tableData;
        }
    }
}
