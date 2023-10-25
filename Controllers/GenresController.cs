using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Entities;


namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("api/genres")]
    public class GenresController : ControllerBase
    {
        private List<Genre> genres;

        private readonly ILogger<GenresController> _logger;

        public GenresController(ILogger<GenresController> logger)
        {
            _logger = logger;

            genres = new List<Genre>()
            {
                new Genre { Id = 1, Name = "Action" },
                new Genre { Id = 2, Name = "Comedy" },
                new Genre { Id = 3, Name = "Drama" },
            };
        }

        [HttpGet]
        public List<Genre> Get()
        {
            return genres;
        }
    }
}