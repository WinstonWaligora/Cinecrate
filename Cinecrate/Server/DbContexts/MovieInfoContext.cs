using Microsoft.EntityFrameworkCore;
using Cinecrate.Shared.Entities;

namespace Server.DbContexts
{
    public class MovieInfoContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieTag> MovieTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<Movie>().ToTable("Movie");
            modelBuilder.Entity<MovieTag>().ToTable("Movie Tag").HasKey(movieTag => new { movieTag.MovieId, movieTag.TagId });
			modelBuilder.Entity<Tag>().ToTable("Tag");
		}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("connectionString");
        //    base.OnConfiguring(optionsBuilder);
        //}
        public MovieInfoContext(DbContextOptions<MovieInfoContext> options) : base(options) { }
    }
}
