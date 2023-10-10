using Microsoft.EntityFrameworkCore;
using Cinecrate.Shared.Models;

namespace Server.DbContexts
{
    public class MovieInfoContext : DbContext
    {
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<MovieTag> MovieTag { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieTag>().HasKey(movieTag => new { movieTag.MovieId, movieTag.TagId });
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("connectionString");
        //    base.OnConfiguring(optionsBuilder);
        //}
        public MovieInfoContext(DbContextOptions<MovieInfoContext> options) : base(options) { }
    }
}
