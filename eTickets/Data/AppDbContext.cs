using eTickets.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movies>()
                .HasKey(am => new
                {
                    am.ActorId,
                    am.MovieId
                });
            modelBuilder.Entity<Actor_Movies>()
                .HasOne(m => m.Movie)
                .WithMany(am => am.Actor_Movies)
                .HasForeignKey(m => m.MovieId);

            modelBuilder.Entity<Actor_Movies>()
                .HasOne(m => m.Actor)
                .WithMany(am => am.Actor_Movies)
                .HasForeignKey(m => m.ActorId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Actor_Movies> Actor_Movies { get; set; }

        // Order related tables

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
