using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinecrate.Shared.Entities
{
    public class Tag
    {
        // The related MovieTags that have the same TagId
        public IEnumerable<MovieTag> MovieTags { get; set; } = new List<MovieTag>();

        // Primary key of the tag entity
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Tag ID", TypeName = "uniqueidentifier")]
        public Guid TagId { get; set; }

        // Name of the tag
        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }
    }
}
