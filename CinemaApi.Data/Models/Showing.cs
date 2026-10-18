namespace CinemaApi.Data.Models
{
    public class Showing
    {
        public Guid Id { get; set; }
        public Film Film { get; set; }
        public Cinema Cinema { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
