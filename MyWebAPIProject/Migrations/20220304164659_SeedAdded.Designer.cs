﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyWebAPIProject.Data;

namespace MyWebAPIProject.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220304164659_SeedAdded")]
    partial class SeedAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ActorMovie", b =>
                {
                    b.Property<int>("ActorsId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.HasKey("ActorsId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("ActorMovie");
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.Property<int>("GenresId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.HasKey("GenresId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("GenreMovie");
                });

            modelBuilder.Entity("MyWebAPIProject.Model.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Actors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Brad Pitt"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Leonardo Di Caprio"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Matthew McConaughy"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Christoph Waltz"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Martin Freeman"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Ian McKellen"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Robert De Niro"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Hugh Jackman"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Arnold Schwartzeneger"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Sam Worthington"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Kurt Russell"
                        });
                });

            modelBuilder.Entity("MyWebAPIProject.Model.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Directors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Christopher Nolan"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Quentine Tarantino"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Martin Scorsese"
                        },
                        new
                        {
                            Id = 4,
                            Name = "James Cameron"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Michael Jackson"
                        });
                });

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
                            Name = "Crime"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Adventure"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Sci-Fi"
                        });
                });

            modelBuilder.Entity("MyWebAPIProject.Model.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DirectorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DirectorId = 4,
                            Name = "Avatar",
                            ReleaseDate = new DateTime(2022, 3, 4, 20, 16, 56, 523, DateTimeKind.Local).AddTicks(7365)
                        },
                        new
                        {
                            Id = 2,
                            DirectorId = 4,
                            Name = "Terminator",
                            ReleaseDate = new DateTime(2022, 3, 4, 20, 16, 56, 533, DateTimeKind.Local).AddTicks(7371)
                        },
                        new
                        {
                            Id = 3,
                            DirectorId = 2,
                            Name = "Hateful Eight",
                            ReleaseDate = new DateTime(2022, 3, 4, 20, 16, 56, 533, DateTimeKind.Local).AddTicks(7371)
                        },
                        new
                        {
                            Id = 4,
                            DirectorId = 2,
                            Name = "Inglorious Bastards",
                            ReleaseDate = new DateTime(2022, 3, 4, 20, 16, 56, 533, DateTimeKind.Local).AddTicks(7371)
                        },
                        new
                        {
                            Id = 5,
                            DirectorId = 2,
                            Name = "Django Unchained",
                            ReleaseDate = new DateTime(2022, 3, 4, 20, 16, 56, 533, DateTimeKind.Local).AddTicks(7371)
                        },
                        new
                        {
                            Id = 6,
                            DirectorId = 1,
                            Name = "Interstellar",
                            ReleaseDate = new DateTime(2022, 3, 4, 20, 16, 56, 533, DateTimeKind.Local).AddTicks(7371)
                        },
                        new
                        {
                            Id = 7,
                            DirectorId = 1,
                            Name = "Prestige",
                            ReleaseDate = new DateTime(2022, 3, 4, 20, 16, 56, 533, DateTimeKind.Local).AddTicks(7371)
                        },
                        new
                        {
                            Id = 8,
                            DirectorId = 1,
                            Name = "Inception",
                            ReleaseDate = new DateTime(2022, 3, 4, 20, 16, 56, 533, DateTimeKind.Local).AddTicks(7371)
                        },
                        new
                        {
                            Id = 9,
                            DirectorId = 5,
                            Name = "The Lord of the Rings",
                            ReleaseDate = new DateTime(2022, 3, 4, 20, 16, 56, 533, DateTimeKind.Local).AddTicks(7371)
                        },
                        new
                        {
                            Id = 10,
                            DirectorId = 5,
                            Name = "The Hobbit",
                            ReleaseDate = new DateTime(2022, 3, 4, 20, 16, 56, 533, DateTimeKind.Local).AddTicks(7371)
                        },
                        new
                        {
                            Id = 11,
                            DirectorId = 3,
                            Name = "The Wolf of Wall Street",
                            ReleaseDate = new DateTime(2022, 3, 4, 20, 16, 56, 533, DateTimeKind.Local).AddTicks(7371)
                        },
                        new
                        {
                            Id = 12,
                            DirectorId = 3,
                            Name = "Taxi Driver",
                            ReleaseDate = new DateTime(2022, 3, 4, 20, 16, 56, 533, DateTimeKind.Local).AddTicks(7371)
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

            modelBuilder.Entity("ActorMovie", b =>
                {
                    b.HasOne("MyWebAPIProject.Model.Actor", null)
                        .WithMany()
                        .HasForeignKey("ActorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyWebAPIProject.Model.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.HasOne("MyWebAPIProject.Model.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyWebAPIProject.Model.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyWebAPIProject.Model.Movie", b =>
                {
                    b.HasOne("MyWebAPIProject.Model.Director", "Director")
                        .WithMany("Movies")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Director");
                });

            modelBuilder.Entity("MyWebAPIProject.Model.Director", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
