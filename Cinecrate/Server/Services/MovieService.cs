using Microsoft.EntityFrameworkCore;
using Server.DbContexts;
using AutoMapper;
using Cinecrate.Shared.Entities;
using Cinecrate.Shared.Models;

namespace Cinecrate.Server.Services
{
	public class MovieService : IMovieService
	{
		private readonly MovieInfoContext _context;
		private readonly IMapper _mapper;
		public MovieService(IConfiguration configuration, MovieInfoContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<MovieWithTagsDto> CreateMovie(MovieWithTagsDto movieWithTagsDto)
		{
			var movie = _mapper.Map<Movie>(movieWithTagsDto);
			_context.Movies.Add(movie);

			var tagDtos = movieWithTagsDto.Tags ?? new List<TagDto>();
			foreach (var tagDto in tagDtos)
			{
				var tag = _mapper.Map<Tag>(tagDto);
				_context.Tags.Add(tag);
				_context.MovieTags.Add(new MovieTag
				{
					Movie = movie,
					Tag = tag
				});
			}

			await _context.SaveChangesAsync();

			return _mapper.Map<MovieWithTagsDto>(movie);
		}

		public void DeleteMovies()
		{
			throw new NotImplementedException();
		}

		public async Task DeleteMovie(Guid movieId)
		{
			var movie = _context.Movies.FirstOrDefault(m => m.MovieId == movieId);
			if (movie != null)
			{
				var movieTags = _context.MovieTags.Where(mt => mt.MovieId == movieId);
				_context.MovieTags.RemoveRange(movieTags);
				_context.Movies.Remove(movie);
				await _context.SaveChangesAsync();
			}
			else
			{
				// Handle the case where the movie with the specified ID is not found
				throw new FileNotFoundException($"Movie with ID {movieId} not found.");
			}
		}

		public async Task<IEnumerable<MovieDto?>> GetMovies()
		{
			var movies = await _context.Movies.ToListAsync();
			var moviesDto = _mapper.Map<IEnumerable<MovieDto>>(movies);
			return moviesDto;
		}

		public async Task<IEnumerable<MovieWithTagsDto?>> GetMoviesWithTags()
		{
			var movies = await _context.Movies.Include(movie => movie.MovieTags).ThenInclude(movieTag => movieTag.Tag).ToListAsync();
			var moviesDto = _mapper.Map<IEnumerable<MovieWithTagsDto>>(movies);
			return moviesDto;
		}

		public async Task<MovieDto?> GetMovie(Guid movieId)
		{
			var movie = await _context.Movies.Where(movie => movie.MovieId == movieId).FirstOrDefaultAsync();
			var movieDto = _mapper.Map<MovieDto>(movie);
			return movieDto;
		}

		public async Task<MovieWithTagsDto?> GetMovieWithTags(Guid movieId)
		{
			var movie = await _context.Movies.Where(movie => movie.MovieId == movieId).Include(movie => movie.MovieTags).ThenInclude(movieTag => movieTag.Tag).FirstOrDefaultAsync();
			var movieWithTagsDto = _mapper.Map<MovieWithTagsDto>(movie);
			return movieWithTagsDto;
		}

		public Task<Guid> UpdateMovie(MovieWithTagsDto movieDto)
		{
			throw new NotImplementedException();
		}
	}

}
