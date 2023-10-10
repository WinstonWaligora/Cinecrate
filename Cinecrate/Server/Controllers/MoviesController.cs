using Microsoft.AspNetCore.Mvc;
using Cinecrate.Shared.Models;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private static readonly string[] titles = new[]
        {
            "Titanic",
            "E.T. the Extra-Terrestrial",
            "The Wizard of Oz",
            "Star Wars: Episode Iv - A New Hope",
            "The Lord of the Rings: The Return of the King",
            "Snow White and the Seven Dwarfs",
            "Terminator 2: Judgement Day",
            "The Lion King",
            "The Godfather",
            "The Jesus Film",
            "Jurassic Park",
            "Indiana Jones and the Raiders of the Lost Ark",
            "Harry Potter and the Sorcerer's Stone",
            "The Shawshank Redemption",
            "Shindler's List",
            "The Dark Knight",
            "Pirates of the Caribbean: The Curse of the Black Pearl",
            "Jaws",
            "Fight Club",
            "Pulp Fiction",
            "Forrest Gump",
            "Shrek",
            "Transformers",
            "Back to the Future",
            "Citizen Kane",
            "Psycho",
            "The Sound of Music",
            "Ben-Hur",
            "Gone with the Wind",
            "Saving Private Ryan",
            "City of God",
            "The Matrix",
            "Braveheart",
            "It's a Wonderful Life",
            "Scarface",
            "Seven Samurai",
            "Casablanca",
            "Gladiator",
            "The Avengers",
            "The Ten Commandments",
        };

        private readonly ILogger<MoviesController> _logger;

        public MoviesController(ILogger<MoviesController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public ActionResult<Movie[]> GetMovies()
        {
            Movie[] movies = Enumerable.Range(0, titles.Length).Select(index => new Movie
            {
                MovieId = Guid.NewGuid(),
                Title = titles[index]
            })
            .ToArray();

            _logger.LogInformation($"GetMovies returned {movies.Length} movies.");

            return Ok(movies);
        }

        [HttpGet("{id}", Name = "GetMovie")]
        public ActionResult<Movie> GetMovie(Guid id)
        {
            //if (id >= titles.Length || id < 0)
            //{
            //    return NotFound();
            //}
            //Movie movie = new Movie { MovieId = id, Title = titles[id] };
            //return Ok(movie);
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult<Movie> CreateMovie(string title)
        {
            return CreatedAtRoute("GetMovie", new Movie {Title = title}, titles.Length);
        }

        [HttpPut("{id}")]
        public ActionResult<Movie> UpdateMovie(string title, int id)
        {
            //if (id >= titles.Length || id < 0)
            //{
            //    return NotFound();
            //}
            //Movie updatedMovie = new Movie{MovieId = id, Title = title};

            //return Ok(updatedMovie);
            throw new NotImplementedException();
        }

        [HttpPatch("{id}")]
        public ActionResult<Movie> PartiallyUpdateMovie(string title, int id)
        {
            //if (id >= titles.Length || id < 0)
            //{
            //    return NotFound();
            //}
            //Movie updatedMovie = new Movie { MovieId = id, Title = title };

            //return Ok(updatedMovie);
            throw new NotImplementedException();
        }
    }
}
