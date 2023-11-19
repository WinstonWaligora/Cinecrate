using Microsoft.AspNetCore.Mvc;
using Cinecrate.Server.Services;
using AutoMapper;
using Cinecrate.Shared.Entities;
using Cinecrate.Shared.Models;

namespace Server.Controllers
{
    [ApiController]
	[Route("[controller]")]
	public class MoviesController : ControllerBase
	{
		private readonly ILogger<MoviesController> _logger;
		private readonly IMovieService _movieService;

		public MoviesController(ILogger<MoviesController> logger, IMovieService movieService, IMapper mapper)
		{
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
			_movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
		}

		[HttpGet]
		[Produces("application/json")]
		public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovies()
		{
			var movies = await _movieService.GetMoviesWithTags();
			if (movies == null)
			{
				return NotFound();
			}
			return Ok(movies);
		}

		[HttpGet("{id}", Name = "GetMovie")]
		[Produces("application/json")]
		public async Task<ActionResult<MovieWithTagsDto>> GetMovie(Guid id)
		{
			var movie = await _movieService.GetMovieWithTags(id);
			if (movie == null)
			{
				return NotFound();
			}
			return Ok(movie);
		}

		[HttpPost]
		public ActionResult<Movie> CreateMovie(string title)
		{
			throw new NotImplementedException();
		}

		[HttpPut("{id}")]
		public ActionResult<Movie> UpdateMovie(string title, int id)
		{
			throw new NotImplementedException();
		}

		[HttpPatch("{id}")]
		public ActionResult<Movie> PartiallyUpdateMovie(string title, int id)
		{
			throw new NotImplementedException();
		}
	}
}
