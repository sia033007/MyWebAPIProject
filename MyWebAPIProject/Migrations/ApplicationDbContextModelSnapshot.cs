﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyWebAPIProject.Data;

namespace MyWebAPIProject.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyWebAPIProject.Model.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Drama"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Crime"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Thriller"
                        },
                        new
                        {
                            Id = 4,
                            Name = "War"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Horror"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Adventure"
                        });
                });

            modelBuilder.Entity("MyWebAPIProject.Model.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Director")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Director = "Quentine Tarantino",
                            Name = "Pulp Fiction",
                            ReleaseDate = new DateTime(2022, 3, 3, 21, 30, 14, 696, DateTimeKind.Local).AddTicks(9947)
                        },
                        new
                        {
                            Id = 2,
                            Director = "Martin Scorsese",
                            Name = "Taxi Driver",
                            ReleaseDate = new DateTime(2022, 3, 3, 21, 30, 14, 786, DateTimeKind.Local).AddTicks(9999)
                        },
                        new
                        {
                            Id = 3,
                            Director = "Michael Jackson",
                            Name = "Hobbit",
                            ReleaseDate = new DateTime(2022, 3, 3, 21, 30, 14, 786, DateTimeKind.Local).AddTicks(9999)
                        },
                        new
                        {
                            Id = 4,
                            Director = "Mel Gibson",
                            Name = "1917",
                            ReleaseDate = new DateTime(2022, 3, 3, 21, 30, 14, 786, DateTimeKind.Local).AddTicks(9999)
                        },
                        new
                        {
                            Id = 5,
                            Director = "James Wan",
                            Name = "Conjuring",
                            ReleaseDate = new DateTime(2022, 3, 3, 21, 30, 14, 786, DateTimeKind.Local).AddTicks(9999)
                        },
                        new
                        {
                            Id = 6,
                            Director = "Alfred Hitchcuck",
                            Name = "Rear Window",
                            ReleaseDate = new DateTime(2022, 3, 3, 21, 30, 14, 786, DateTimeKind.Local).AddTicks(9999)
                        });
                });

            modelBuilder.Entity("MyWebAPIProject.Model.MovieGenre", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("MovieGenres");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            GenreId = 2
                        },
                        new
                        {
                            MovieId = 2,
                            GenreId = 2
                        },
                        new
                        {
                            MovieId = 3,
                            GenreId = 6
                        },
                        new
                        {
                            MovieId = 3,
                            GenreId = 8
                        },
                        new
                        {
                            MovieId = 4,
                            GenreId = 1
                        },
                        new
                        {
                            MovieId = 4,
                            GenreId = 4
                        },
                        new
                        {
                            MovieId = 4,
                            GenreId = 5
                        },
                        new
                        {
                            MovieId = 5,
                            GenreId = 7
                        },
                        new
                        {
                            MovieId = 6,
                            GenreId = 3
                        });
                });

            modelBuilder.Entity("MyWebAPIProject.Model.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("MyWebAPIProject.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MyWebAPIProject.Model.MovieGenre", b =>
                {
                    b.HasOne("MyWebAPIProject.Model.Genre", "Genre")
                        .WithMany("MovieGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyWebAPIProject.Model.Movie", "Movie")
                        .WithMany("MovieGenres")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MyWebAPIProject.Model.Genre", b =>
                {
                    b.Navigation("MovieGenres");
                });

            modelBuilder.Entity("MyWebAPIProject.Model.Movie", b =>
                {
                    b.Navigation("MovieGenres");
                });
#pragma warning restore 612, 618
        }
    }
}
