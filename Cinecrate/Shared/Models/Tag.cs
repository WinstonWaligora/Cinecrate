using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinecrate.Shared.Models
{
    public class Tag
    {
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
