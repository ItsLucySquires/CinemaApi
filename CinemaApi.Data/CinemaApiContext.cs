using Microsoft.EntityFrameworkCore;
using CinemaApi.Data.Models;

public class CinemaApiContext(DbContextOptions<CinemaApiContext> options) : DbContext(options)
{
    public DbSet<Cinema> Cinema { get; set; } = default!;
    public DbSet<Film> Film { get; set; } = default!;
    public DbSet<Showing> Showing { get; set; } = default!;
}
