namespace CodingTracker.Models
{
    public class CodingSessions
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public TimeSpan GetDuration()
        {
            return EndTime - StartTime;
        }

        public string GetFormattedDuration()
        {
            return GetDuration().ToString(@"hh\:mm");
        }

    }
}
