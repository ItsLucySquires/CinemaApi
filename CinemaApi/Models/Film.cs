namespace CinemaApi.Models
{
    public class Film
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public TimeSpan Duration { get; set; }
        public string AgeRating { get; set; }
    }
}
