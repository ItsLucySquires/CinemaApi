using CinemaApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

public class CinemaApiContext(DbContextOptions<CinemaApiContext> options) : DbContext(options)
{
    public DbSet<Cinema> Cinema { get; set; } = default!;
    public DbSet<Film> Film { get; set; } = default!;
    public DbSet<Showing> Showing { get; set; } = default!;
    public DbSet<Screen> Screen { get; set; } = default!;
    public DbSet<Seat> Seat { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define IDs for relations
        var cinemaId1 = Guid.Parse("11111111-1111-1111-1111-111111111111");
        var cinemaId2 = Guid.Parse("22222222-2222-2222-2222-222222222222");
        var cinemaId3 = Guid.Parse("33333333-3333-3333-3333-333333333333");
        var cinemaId4 = Guid.Parse("44444444-4444-4444-4444-444444444444");

        var filmId1 = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
        var filmId2 = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");
        var filmId3 = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc");

        var screenId1 = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd");
        var screenId2 = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee");
        var screenId3 = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff");

        #region FilmSeed
        modelBuilder.Entity<Film>(b =>
        {
            b.HasData(
                new Film
                {
                    Id = filmId1,
                    Title = "Star Wars Episode III Revenge of the Sith",
                    ReleaseDate = new DateTime(2005, 5, 19),
                    Duration = TimeSpan.FromMinutes(140),
                    AgeRating = "PG-13"
                },
                new Film
                {
                    Id = filmId2,
                    Title = "Inception",
                    ReleaseDate = new DateTime(2010, 7, 16),
                    Duration = TimeSpan.FromMinutes(148),
                    AgeRating = "PG-13"
                },
                new Film
                {
                    Id = filmId3,
                    Title = "Interstellar",
                    ReleaseDate = new DateTime(2014, 11, 7),
                    Duration = TimeSpan.FromMinutes(169),
                    AgeRating = "PG-13"
                });
        });
        #endregion

        #region CinemaSeed
        modelBuilder.Entity<Cinema>().HasData(
            new Cinema
            {
                Id = cinemaId1,
                Name = "Seattle Cinema",
                Address = "123 Pike Place, Seattle, WA"
            },
            new Cinema
            {
                Id = cinemaId2,
                Name = "Vancouver Theater",
                Address = "456 Granville St, Vancouver, BC"
            },
            new Cinema
            {
                Id = cinemaId3,
                Name = "Mexico City Multiplex",
                Address = "789 Avenida Paseo de la Reforma, Mexico City"
            },
            new Cinema
            {
                Id = cinemaId4,
                Name = "Puebla Cinema Hall",
                Address = "321 Calle 5 de Oriente, Puebla"
            });
        #endregion

        #region ScreenSeed
        modelBuilder.Entity<Screen>().HasData(
            new Screen
            {
                Id = screenId1,
                Name = "Screen 1 - IMAX",
                TypeDescription = "IMAX Theater",
                CinemaId = cinemaId1
            },
            new Screen
            {
                Id = screenId2,
                Name = "Screen 2 - Standard",
                TypeDescription = "Standard Theater",
                CinemaId = cinemaId1
            },
            new Screen
            {
                Id = screenId3,
                Name = "Screen 1 - Premium",
                TypeDescription = "Premium Theater with Reclining Seats",
                CinemaId = cinemaId2
            });
        #endregion

        #region SeatSeed
        modelBuilder.Entity<Seat>().HasData(
            new Seat { Id = Guid.Parse("50000000-0000-0000-0000-000000000001"), Row = "A", Number = 1, ScreenId = screenId1 },
            new Seat { Id = Guid.Parse("50000000-0000-0000-0000-000000000002"), Row = "A", Number = 2, ScreenId = screenId1 },
            new Seat { Id = Guid.Parse("50000000-0000-0000-0000-000000000003"), Row = "A", Number = 3, ScreenId = screenId1 },
            new Seat { Id = Guid.Parse("50000000-0000-0000-0000-000000000004"), Row = "B", Number = 1, ScreenId = screenId1 },
            new Seat { Id = Guid.Parse("50000000-0000-0000-0000-000000000005"), Row = "B", Number = 2, ScreenId = screenId1 },
            new Seat { Id = Guid.Parse("50000000-0000-0000-0000-000000000006"), Row = "A", Number = 1, ScreenId = screenId2 },
            new Seat { Id = Guid.Parse("50000000-0000-0000-0000-000000000007"), Row = "A", Number = 2, ScreenId = screenId2 },
            new Seat { Id = Guid.Parse("50000000-0000-0000-0000-000000000008"), Row = "A", Number = 1, ScreenId = screenId3 },
            new Seat { Id = Guid.Parse("50000000-0000-0000-0000-000000000009"), Row = "A", Number = 2, ScreenId = screenId3 });
        #endregion

        #region ShowingSeed
        modelBuilder.Entity<Showing>().HasData(
            new Showing
            {
                Id = Guid.Parse("60000000-0000-0000-0000-000000000001"),
                FilmId = filmId1,
                CinemaId = cinemaId1,
                StartTime = new DateTime(2024, 12, 20, 14, 0, 0),
                EndTime = new DateTime(2024, 12, 20, 16, 20, 0)
            },
            new Showing
            {
                Id = Guid.Parse("60000000-0000-0000-0000-000000000002"),
                FilmId = filmId1,
                CinemaId = cinemaId1,
                StartTime = new DateTime(2024, 12, 20, 19, 0, 0),
                EndTime = new DateTime(2024, 12, 20, 21, 20, 0)
            },
            new Showing
            {
                Id = Guid.Parse("60000000-0000-0000-0000-000000000003"),
                FilmId = filmId2,
                CinemaId = cinemaId2,
                StartTime = new DateTime(2024, 12, 20, 16, 0, 0),
                EndTime = new DateTime(2024, 12, 20, 18, 28, 0)
            },
            new Showing
            {
                Id = Guid.Parse("60000000-0000-0000-0000-000000000004"),
                FilmId = filmId3,
                CinemaId = cinemaId2,
                StartTime = new DateTime(2024, 12, 20, 20, 0, 0),
                EndTime = new DateTime(2024, 12, 20, 22, 49, 0)
            },
            new Showing
            {
                Id = Guid.Parse("60000000-0000-0000-0000-000000000005"),
                FilmId = filmId2,
                CinemaId = cinemaId3,
                StartTime = new DateTime(2024, 12, 21, 15, 0, 0),
                EndTime = new DateTime(2024, 12, 21, 17, 28, 0)
            });
        #endregion
    }
}
