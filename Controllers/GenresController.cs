using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Entities;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("api/genres")]
    public class GenresController : ControllerBase
    {
        
        private readonly IRepository repository;
        private readonly ILogger logger;

        public GenresController(IRepository repository, ILogger<GenresController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        [HttpGet] // api/genres
        [HttpGet("list")] // api/genres/list (multiple routing options)
        [HttpGet("/allgenres")] // starting with a / over write the main routing
        public async Task<List<Genre>> Get()
        {
            logger.LogInformation("Getting all the genres");
            return await repository.GetAllGenres();
        }


        [HttpGet("{Id:int}/{param=API}")] // 2 parameters, first with type constaint and second with a default value
        public ActionResult<Genre> Get(int id, string param) //ActionResult types represent various HTTP status codes
        {
            logger.LogDebug("Get Genre by id executing..");
            var genre = repository.GetGenreById(id);

            if (genre == null) {
                logger.LogWarning($"Genre with Id {id} not found");
                return NotFound();
             };

            return genre;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Genre genre) //requre the parameter to come from the body only
        {
            /* not required if using [apicontroller]
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            */

            repository.AddGenre(genre);
            return NoContent();
        }

      
    }
}