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
			var movieDtos = await _movieService.GetMoviesWithTags();
			if (movieDtos == null)
			{
				return NotFound();
			}
			return Ok(movieDtos);
		}

		[HttpGet("{id}", Name = "GetMovie")]
		[Produces("application/json")]
		public async Task<ActionResult<MovieWithTagsDto>> GetMovie(Guid id)
		{
			var movieDto = await _movieService.GetMovieWithTags(id);
			if (movieDto == null)
			{
				return NotFound();
			}
			return Ok(movieDto);
		}

		[HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<MovieWithTagsDto>> CreateMovie(MovieWithTagsDto movieWithTagsDtoInput)
		{
            var movieDto = await _movieService.CreateMovie(movieWithTagsDtoInput);
            if (movieDto == null)
            {
                return NotFound();
            }
            return Ok(movieDto);
		}

		[HttpPut("{id}")]
        [Produces("application/json")]
        public ActionResult<MovieWithTagsDto> UpdateMovie(string title, int id)
		{
			throw new NotImplementedException();
		}

		[HttpPatch("{id}")]
        [Produces("application/json")]
        public ActionResult<MovieWithTagsDto> PartiallyUpdateMovie(string title, int id)
		{
			throw new NotImplementedException();
		}
	}
}
