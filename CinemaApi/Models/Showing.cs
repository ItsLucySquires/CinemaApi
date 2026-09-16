namespace CinemaApi.Models
{
    public class Showing
    {
        public Guid Id { get; set; }
        public Guid FilmId { get; set; }
        public Guid CinemaId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
