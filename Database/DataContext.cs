using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Database
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users {get; set;}
        public DbSet<Comment> Comments {get; set;}
        public DbSet<Rating> Ratings {get; set;}
        public DbSet<Movie> Movies {get; set;}
        public DbSet<Series> Series {get; set;}
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            builder.Entity<Movie>()
            .HasMany(r => r.Ratings)
            .WithOne(m => m.Movie)
            .HasForeignKey(r => r.MovieID)
            .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Movie>()
            .HasMany(c => c.Comments)
            .WithOne(m => m.Movie)
            .HasForeignKey(c => c.MovieID)
            .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Movie>()
            .HasMany(m => m.SeenBy)
            .WithMany(u => u.SeenMovies);

            builder.Entity<User>()
            .HasMany(c => c.Comments)
            .WithOne(u => u.User)
            .HasForeignKey(c => c.UserID)
            .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<User>()
            .HasMany(r => r.Ratings)
            .WithOne(u => u.User)
            .HasForeignKey(r => r.UserID)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}