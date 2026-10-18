namespace CinemaApi.Data.Models
{
    public class Cinema
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Screen> Screens { get; set; }
    }
}
