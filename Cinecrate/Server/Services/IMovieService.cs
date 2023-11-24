using Cinecrate.Shared.Entities;
using Cinecrate.Shared.Models;

namespace Cinecrate.Server.Services
{
    public interface IMovieService
	{
		Task<MovieWithTagsDto> CreateMovie(MovieWithTagsDto movieWithTagsDto);
		void DeleteMovies();
		void DeleteMovie(Guid movieId);
		Task<IEnumerable<MovieDto?>> GetMovies();
		Task<IEnumerable<MovieWithTagsDto?>> GetMoviesWithTags();
		Task<MovieDto?> GetMovie(Guid movieId);
		Task<MovieWithTagsDto?> GetMovieWithTags(Guid movieId);
		Task<Guid> UpdateMovie(MovieWithTagsDto movieDto);
	}
}
