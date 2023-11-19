using Microsoft.EntityFrameworkCore;
using Server.DbContexts;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Cinecrate.Shared.Entities;
using Cinecrate.Shared.Models;

namespace Cinecrate.Server.Services
{
	public class MovieService : IMovieService
	{
		private readonly string _dbConnectionString = string.Empty;
		private readonly MovieInfoContext _context;
		private readonly IMapper _mapper;
		public MovieService(IConfiguration configuration, MovieInfoContext context, IMapper mapper)
		{
			_dbConnectionString = configuration["LocalSQLServer"];
			_context = context;
			_mapper = mapper;
		}

		public Task<Guid> CreateMovie(Movie movie)
		{
			throw new NotImplementedException();
		}

		public void DeleteMovies()
		{
			throw new NotImplementedException();
		}

		public void DeleteMovie(Guid movieId)
		{
			throw new NotImplementedException();
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

		public Task<Guid> UpdateMovie(Movie movie)
		{
			throw new NotImplementedException();
		}
	}
}
