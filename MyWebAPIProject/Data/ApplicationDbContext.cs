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
        public DbSet<Director> Directors { get; set; }
        public DbSet<Actor> Actors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Director>().HasData(
                new Director
                {
                    Id = 1,
                    Name = "Christopher Nolan"
                },
                new Director
                {
                    Id = 2,
                    Name = "Quentine Tarantino"
                },
                new Director
                {
                    Id = 3,
                    Name = "Martin Scorsese"
                },
                new Director
                {
                    Id = 4,
                    Name = "James Cameron"
                },
                new Director
                {
                    Id = 5,
                    Name = "Peter Jackson"
                },
                new Director
                {
                    Id = 6,
                    Name = "Steven Spielberg"
                },
                new Director
                {
                    Id = 7,
                    Name = "Ford Coppolla"
                },
                new Director
                {
                    Id = 8,
                    Name = "Frank Darabont"
                },
                new Director
                {
                    Id = 9,
                    Name = "David Fincher"
                }
                );
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Name = "Avatar",
                    DirectorId = 4
                },
                new Movie
                {
                    Id = 2,
                    Name = "Terminator",
                    DirectorId = 4
                },
                new Movie
                {
                    Id = 3,
                    Name = "Hateful Eight",
                    DirectorId = 2
                },
                new Movie
                {
                    Id = 4,
                    Name = "Inglorious Bastards",
                    DirectorId = 2
                },
                new Movie
                {
                    Id = 5,
                    Name = "Django Unchained",
                    DirectorId = 2
                },
                new Movie
                {
                    Id = 6,
                    Name = "Interstellar",
                    DirectorId = 1
                },
                new Movie
                {
                    Id = 7,
                    Name = "Prestige",
                    DirectorId = 1
                },
                new Movie
                {
                    Id = 8,
                    Name = "Inception",
                    DirectorId = 1
                },
                new Movie
                {
                    Id = 9,
                    Name = "The Lord of the Rings",
                    DirectorId = 5
                },
                new Movie
                {
                    Id = 10,
                    Name = "The Hobbit",
                    DirectorId = 5
                },
                new Movie
                {
                    Id = 11,
                    Name = "The Wolf of Wall Street",
                    DirectorId = 3
                },
                new Movie
                {
                    Id = 12,
                    Name = "Taxi Driver",
                    DirectorId = 3
                },
                new Movie
                {
                    Id = 13,
                    Name = "Schindler's List",
                    DirectorId = 6
                },
                new Movie
                {
                    Id = 14,
                    Name = "Adventures of Tin Tin",
                    DirectorId = 6
                },
                new Movie
                {
                    Id = 15,
                    Name = "Godfather",
                    DirectorId = 7
                },
                new Movie
                {
                    Id = 16,
                    Name = "Green Mile",
                    DirectorId = 8
                },
                new Movie
                {
                    Id = 17,
                    Name = "Shawshank Redemption",
                    DirectorId = 8
                },
                new Movie
                {
                    Id = 18,
                    Name = "Se7en",
                    DirectorId = 9
                },
                new Movie
                {
                    Id = 19,
                    Name = "Fight Club",
                    DirectorId = 9
                }
                );
            modelBuilder.Entity<Genre>().HasData(
                new Genre
                {
                    Id = 1,
                    Name = "Crime"
                },
                new Genre
                {
                    Id = 2,
                    Name = "Adventure"
                },
                new Genre
                {
                    Id = 3,
                    Name = "Fantasy"
                },
                new Genre
                {
                    Id = 4,
                    Name = "Action"
                },
                new Genre
                {
                    Id = 5,
                    Name = "Sci-Fi"
                },
                new Genre
                {
                    Id = 6,
                    Name = "Animation"
                },
                new Genre
                {
                    Id = 7,
                    Name = "Drama"
                }
                );
            modelBuilder.Entity<Actor>().HasData(
                new Actor
                {
                    Id = 1,
                    Name = "Brad Pitt"
                },
                new Actor
                {
                    Id = 2,
                    Name = "Leonardo Di Caprio"
                },
                new Actor
                {
                    Id = 3,
                    Name = "Matthew McConaughy"
                },
                new Actor
                {
                    Id = 4,
                    Name = "Christoph Waltz"
                },
                new Actor
                {
                    Id = 5,
                    Name = "Martin Freeman"
                },
                new Actor
                {
                    Id = 6,
                    Name = "Ian McKellen"
                },
                new Actor
                {
                    Id = 7,
                    Name = "Robert De Niro"
                },
                new Actor
                {
                    Id = 8,
                    Name = "Hugh Jackman"
                },
                new Actor
                {
                    Id = 9,
                    Name = "Arnold Schwartzeneger"
                },
                new Actor
                {
                    Id = 10,
                    Name = "Sam Worthington"
                },
                new Actor
                {
                    Id = 11,
                    Name = "Kurt Russell"
                },
                new Actor
                {
                    Id = 12,
                    Name = "Tom Hanks"
                },
                new Actor
                {
                    Id = 13,
                    Name = "Samuel L.Jackson"
                },
                new Actor
                {
                    Id = 14,
                    Name = "Morgan Freeman"
                },
                new Actor
                {
                    Id = 15,
                    Name = "Al Pacino"
                },
                new Actor
                {
                    Id = 16,
                    Name = "Edward Norton"
                }
                );
        }

    }
}
