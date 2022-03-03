using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebAPIProject.Model;

namespace MyWebAPIProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
        public DbSet<Player> Players { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MovieGenre>().HasKey(
                mg=> new {mg.MovieId, mg.GenreId}
                
                );
            modelBuilder.Entity<MovieGenre>().HasOne(
                mg => mg.Movie).WithMany(mg => mg.MovieGenres)
                .HasForeignKey(mg => mg.MovieId);
            modelBuilder.Entity<MovieGenre>().HasOne
                (mg => mg.Genre).WithMany(mg => mg.MovieGenres)
                .HasForeignKey(mg => mg.GenreId);

            modelBuilder.Entity<Genre>().HasData(
                new Genre
                {
                    Id = 1,
                    Name = "Drama"
                },
                new Genre
                {
                    Id = 2,
                    Name = "Crime"
                },
                new Genre
                {
                    Id = 3,
                    Name = "Thriller"
                },
                new Genre
                {
                    Id = 4,
                    Name = "War"
                },
                new Genre
                {
                    Id = 5,
                    Name = "Action"
                },
                new Genre
                {
                    Id = 6,
                    Name = "Fantasy"
                },
                new Genre
                {
                    Id = 7,
                    Name = "Horror"
                },
                new Genre
                {
                    Id = 8,
                    Name = "Adventure"
                }

                );
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Name = "Pulp Fiction",
                    Director = "Quentine Tarantino"
                },
                new Movie
                {
                    Id = 2,
                    Name = "Taxi Driver",
                    Director = "Martin Scorsese"
                },
                new Movie
                {
                    Id = 3,
                    Name = "Hobbit",
                    Director = "Michael Jackson"
                },
                new Movie
                {
                    Id = 4,
                    Name = "1917",
                    Director = "Mel Gibson"
                },
                new Movie
                {
                    Id = 5,
                    Name = "Conjuring",
                    Director = "James Wan"
                },
                new Movie
                {
                    Id = 6,
                    Name = "Rear Window",
                    Director = "Alfred Hitchcuck"
                }

                );
            modelBuilder.Entity<MovieGenre>().HasData(
                new MovieGenre
                {
                    MovieId = 1,
                    GenreId = 2
                },
                new MovieGenre
                {
                    MovieId = 2,
                    GenreId = 2
                },
                new MovieGenre
                {
                    MovieId = 3,
                    GenreId = 6
                },
                new MovieGenre
                {
                    MovieId = 3,
                    GenreId = 8
                },
                new MovieGenre
                {
                    MovieId = 4,
                    GenreId = 1
                },
                new MovieGenre
                {
                    MovieId = 4,
                    GenreId = 4
                },
                new MovieGenre
                {
                    MovieId = 4,
                    GenreId = 5
                },
                new MovieGenre
                {
                    MovieId = 5,
                    GenreId = 7
                },
                new MovieGenre
                {
                    MovieId = 6,
                    GenreId = 3
                }
                );


        }

    }
}
