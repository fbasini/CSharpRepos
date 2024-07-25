using CodingTracker.DAO;

namespace CodingTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.InitializeDatabase();
            Menu.ShowMenu();
        }
    }
}
