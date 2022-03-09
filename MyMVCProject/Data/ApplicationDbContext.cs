using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyMVCProject.Models;

namespace MyMVCProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<MyUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
                
        }
        public DbSet<Player> Players { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Player>().Property(p => p.Id).HasColumnName("playerId").HasColumnType("INT").ValueGeneratedOnAdd();
            builder.Entity<Player>().Property(p => p.Name).HasColumnName("playerName").HasColumnType("VARCHAR(50)").IsRequired();
            builder.Entity<Player>().Property(p => p.Position).HasColumnName("playerPosition").HasColumnType("VARCHAR(50)").IsRequired();
            builder.Entity<Player>().Property(p => p.Nationality).HasColumnName("playerNationality").HasColumnType("VARCHAR(50)").IsRequired();
        }
    }
}
