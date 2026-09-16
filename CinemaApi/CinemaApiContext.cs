using Microsoft.EntityFrameworkCore;

public class CinemaApiContext(DbContextOptions<CinemaApiContext> options) : DbContext(options)
{
    public DbSet<CinemaApi.Models.Cinema> Cinema { get; set; } = default!;
    public DbSet<CinemaApi.Models.Film> Film { get; set; } = default!;
    public DbSet<CinemaApi.Models.Showing> Showing { get; set; } = default!;
}
