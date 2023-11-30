namespace Cinecrate.Shared.Models
{
    public class MovieDto
    {
        public string? Description { get; set; }
        public string? Director { get; set; }
        public int? Duration { get; set; }
        public Guid? MovieId { get; set; }
        public string? Poster { get; set; }
        public char? Rating { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? Title { get; set; }
    }
}
