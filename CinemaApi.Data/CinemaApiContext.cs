using Microsoft.EntityFrameworkCore;
using CinemaApi.Data.Models;

public class CinemaApiContext(DbContextOptions<CinemaApiContext> options) : DbContext(options)
{
    public DbSet<Cinema> Cinema { get; set; } = default!;
    public DbSet<Film> Film { get; set; } = default!;
    public DbSet<Showing> Showing { get; set; } = default!;
    public DbSet<Screen> Screen { get; set; } = default!;
    public DbSet<Seat> Seat { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseAsyncSeeding(async (context, _, cancellationToken) =>
            {
                if (!await context.Set<Film>().AnyAsync(cancellationToken))
                {
                    var films = new[]
                    {
                        new Film { Title = "The Shawshank Redemption",
                            ReleaseDate = new DateTimeOffset(new DateTime(1994, 9, 23), TimeSpan.Zero).DateTime },
                        new Film { Title = "The Dark Knight",
                            ReleaseDate = new DateTimeOffset(new DateTime(2008, 7, 18), TimeSpan.Zero).DateTime },
                        new Film { Title = "Inception",
                            ReleaseDate = new DateTimeOffset(new DateTime(2010, 7, 16), TimeSpan.Zero).DateTime },
                        new Film { Title = "Interstellar",
                            ReleaseDate = new DateTimeOffset(new DateTime(2014, 11, 7), TimeSpan.Zero).DateTime },
                        new Film { Title = "The Matrix",
                            ReleaseDate = new DateTimeOffset(new DateTime(1999, 3, 31), TimeSpan.Zero).DateTime }
                    };

                    await context.Set<Film>().AddRangeAsync(films, cancellationToken);
                    await context.SaveChangesAsync(cancellationToken);
                }
                if (!await context.Set<Cinema>().AnyAsync(cancellationToken))
                {
                    var cinemas = new[]
                    {
                        new Cinema { Name = "Cinema 1", Address = "Location 1" },
                        new Cinema { Name = "Cinema 2", Address = "Location 2" },
                    };

                    await context.Set<Cinema>().AddRangeAsync(cinemas, cancellationToken);
                    await context.SaveChangesAsync(cancellationToken);
                }
            })
            .UseSeeding((context, _) =>
            {
                if (!context.Set<Film>().Any())
                {
                    var films = new[]
                    {
                        new Film { Title = "The Shawshank Redemption",
                            ReleaseDate = new DateTimeOffset(new DateTime(1994, 9, 23), TimeSpan.Zero).DateTime },
                        new Film { Title = "The Dark Knight",
                            ReleaseDate = new DateTimeOffset(new DateTime(2008, 7, 18), TimeSpan.Zero).DateTime },
                        new Film { Title = "Inception",
                            ReleaseDate = new DateTimeOffset(new DateTime(2010, 7, 16), TimeSpan.Zero).DateTime },
                        new Film { Title = "Interstellar",
                            ReleaseDate = new DateTimeOffset(new DateTime(2014, 11, 7), TimeSpan.Zero).DateTime },
                        new Film { Title = "The Matrix",
                            ReleaseDate = new DateTimeOffset(new DateTime(1999, 3, 31), TimeSpan.Zero).DateTime }
                    };

                    context.Set<Film>().AddRange(films);
                    context.SaveChanges();
                }
            });
    }
}
