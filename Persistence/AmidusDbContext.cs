using Microsoft.EntityFrameworkCore;
using amidus.Core.Models;

namespace amidus.Persistence
{
    public class AmidusDbContext : DbContext
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public AmidusDbContext(DbContextOptions<AmidusDbContext> options) 
          : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<MovieActors>().HasKey(ma => 
              new { ma.MovieId, ma.ActorId });
        }
    }
}