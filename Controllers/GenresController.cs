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

        public GenresController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet] // api/genres
        [HttpGet("list")] // api/genres/list (multiple routing options)
        [HttpGet("/allgenres")] // starting with a / over write the main routing
        public List<Genre> Get()
        {
            return repository.GetAllGenres();
        }

        [HttpGet("{Id:int}/{param=API}")] // 2 parameters, first with type constaint and second with a default value
        public Genre Get(int id, string param)
        {
            var genre = repository.GetGenreById(id);

            if (genre == null) {
                //return NotFound()
             };

            return genre;
        }
    }
}