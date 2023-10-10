using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinecrate.Shared.Models
{
    [Table("Movie Tag")]
    public class MovieTag
    {
        // Foreign key for Movie
        [ForeignKey("MovieId")]
        public required Movie Movie { get; set; }
        [Key, Column("Movie ID", Order = 0, TypeName = "uniqueidentifier")]
        public Guid MovieId { get; set; }

        // Foreign key for Tag
        [ForeignKey("TagId")]
        public required Tag Tag { get; set; }
        [Key, Column("Tag ID", Order = 1, TypeName = "uniqueidentifier")]
        public Guid TagId { get; set; }
    }
}