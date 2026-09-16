using Microsoft.EntityFrameworkCore;

public class CinemaApiContext(DbContextOptions<CinemaApiContext> options) : DbContext(options)
{
    public DbSet<CinemaApi.Models.Cinema> Cinema { get; set; } = default!;
}
