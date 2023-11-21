using Microsoft.EntityFrameworkCore;

namespace GameSphere.Models
{
    public class VideoGameContext : DbContext
    {
        public VideoGameContext(DbContextOptions<VideoGameContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Console> Consoles { get; set; }
        public DbSet<VideoGame> VideoGames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreId = 1, Name = "Puzzle" },
                new Genre { GenreId = 2, Name = "Platformer" },
                new Genre { GenreId = 3, Name = "Role-Playing" },
                new Genre { GenreId = 4, Name = "First-Person Shooter" },
                new Genre { GenreId = 5, Name = "Sports" },
                new Genre { GenreId = 6, Name = "Racing" },
                new Genre { GenreId = 7, Name = "Fighting" },
                new Genre { GenreId = 8, Name = "Simulation" },
                new Genre { GenreId = 9, Name = "MMO" },
                new Genre { GenreId = 10, Name = "Survival Horror" },
                new Genre { GenreId = 11, Name = "Real-Time Strategy" },
                new Genre { GenreId = 12, Name = "Turn-Based Strategy" },
                new Genre { GenreId = 13, Name = "Rhythm" }
            );

            modelBuilder.Entity<Console>().HasData(
                new Console { ConsoleId = 1, Name = "NES" },
                new Console { ConsoleId = 2, Name = "Sega Genesis" },
                new Console { ConsoleId = 3, Name = "SNES" },
                new Console { ConsoleId = 4, Name = "Game Boy" },
                new Console { ConsoleId = 5, Name = "Sega Saturn" },
                new Console { ConsoleId = 6, Name = "PlayStation 1" },
                new Console { ConsoleId = 7, Name = "Nintendo 64" },
                new Console { ConsoleId = 8, Name = "Dreamcast" },
                new Console { ConsoleId = 9, Name = "PlayStation 2" },
                new Console { ConsoleId = 10, Name = "Game Boy Advance" },
                new Console { ConsoleId = 11, Name = "GameCube" },
                new Console { ConsoleId = 12, Name = "Xbox" },
                new Console { ConsoleId = 13, Name = "DS" },
                new Console { ConsoleId = 14, Name = "PSP" },
                new Console { ConsoleId = 15, Name = "Xbox 360" },
                new Console { ConsoleId = 16, Name = "PlayStation 3" },
                new Console { ConsoleId = 17, Name = "Wii" },
                new Console { ConsoleId = 18, Name = "3DS" },
                new Console { ConsoleId = 19, Name = "Wii U" },
                new Console { ConsoleId = 20, Name = "PlayStation 4" },
                new Console { ConsoleId = 21, Name = "Xbox Series One" },
                new Console { ConsoleId = 22, Name = "Nintendo Switch" },
                new Console { ConsoleId = 23, Name = "Xbox Series X/S" },
                new Console { ConsoleId = 24, Name = "PlayStation 5" },
                new Console { ConsoleId = 25, Name = "PC" }
            );

            modelBuilder.Entity<VideoGame>().HasData(
                new VideoGame 
                { 
                    VideoGameId = 1,
                    Title = "Super Mario Bros.",
                    Developer = "Nintendo",
                    Publisher = "Nintendo",
                    GenreId = 2,
                    PurchaseDate = new DateTime(2010, 05, 09, 0, 0, 0),
                    ConsoleId = 1
                }
            );
        }
    }
}
