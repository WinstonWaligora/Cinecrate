using Cinecrate.Shared.Entities;
using Cinecrate.Shared.Models;

namespace Cinecrate.Server.Services
{
    public interface IMovieService
	{
		Task<Guid> CreateMovie(Movie movie);
		void DeleteAll();
		void DeleteMovie(Guid movieId);
		Task<IEnumerable<MovieDto?>> GetAll();
		Task<MovieDto?> GetMovie(Guid movieId);
		Task<MovieWithTagsDto?> GetMovieWithTags(Guid movieId);
		Task<Guid> UpdateMovie(Movie movie);
	}
}
