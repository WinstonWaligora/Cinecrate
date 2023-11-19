using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinecrate.Shared.Entities
{
    public class Movie
    {
        // Brief summary of the plot of the movie
        [MaxLength(255)]
        public string? Description { get; set; }

        // Main Director given credit for the movie
        [MaxLength(50)]
        public string? Director { get; set; }

        // The time length of the movie in minutes
        public int? Duration { get; set; }

        // Primary key of the movie entity
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Movie ID", TypeName = "uniqueidentifier")]
        public Guid MovieId { get; set; }

        // The related MovieTags that have the same MovieId
        public IEnumerable<MovieTag> MovieTags { get; set; } = new List<MovieTag>();

        // Image file that shows the poster of the movie
        [Column(TypeName = "varbinary(MAX)")]
        public byte[]? Poster { get; set; }

        // Rating of the movie based on some criteria
        [Range(1, 5, ErrorMessage = "You must enter one to five stars.")]
        [Column(TypeName = "char(1)")]
        public char? Rating { get; set; }

        // Year of release of the movie
        [Column("Release Date", TypeName = "datetime")]
        public DateTime? ReleaseDate { get; set; }

        // Name of the movie
        [Required]
        [MaxLength(50)]
        public required string Title { get; set; }

        public Movie() { }

        public Movie(string title)
        {
            Title = title;
        }

        public Movie(Guid id, string title)
        {
            MovieId = id;
            Title = title;
        }
    }
}
