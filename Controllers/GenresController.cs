using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Entities;
using MoviesAPI.Filters;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("api/genres")]
    public class GenresController : ControllerBase
    {
        
        private readonly ILogger logger;

        public GenresController(ILogger<GenresController> logger)
        {
            this.logger = logger;
        }

        [HttpGet] // api/genres
        //[HttpGet("list")] // api/genres/list (multiple routing options)
        //[HttpGet("/allgenres")] // starting with a / over write the main routing
        //[ResponseCache(Duration = 60)]
        //[ServiceFilter(typeof(MyActionFilter))]
        public async Task<List<Genre>> Get()
        {
            logger.LogInformation("Getting all the genres");
            return new List<Genre>() { new Genre() { Id = 1, Name = "comedy" } };
        }


        [HttpGet("{Id:int}", Name ="getGenre")] // 2 parameters, first with type constaint and second with a default value
        //[ServiceFilter(typeof(MyActionFilter))]
        public ActionResult<Genre> Get(int id, string param) //ActionResult types represent various HTTP status codes
        {
            /*
            logger.LogDebug("Get Genre by id executing..");
            var genre = repository.GetGenreById(id);

            if (genre == null) {
                logger.LogWarning($"Genre with Id {id} not found");
                //throw new ApplicationException(); //exception test
                return NotFound();
             };

            return genre;
            */
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult Post([FromBody] Genre genre) //requre the parameter to come from the body only
        {
            /* not required if using [apicontroller]
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            

            repository.AddGenre(genre);
            return NoContent();
            */
            throw new NotImplementedException();

        }

        [HttpPut]
        public ActionResult Put([FromBody] Genre genre)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public ActionResult Delete() 
        { 
            throw new NotImplementedException(); 
        }

    }
}