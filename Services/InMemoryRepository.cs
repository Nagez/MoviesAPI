using MoviesAPI.Entities;
using System.Collections.Generic;

namespace MoviesAPI.Services
{
    public class InMemoryRepository : IRepository
    {
        private List<Genre> genres;

        public InMemoryRepository()
        {
            genres = new List<Genre>()
            {
                new Genre() {Id = 1, Name = "Action"},
                new Genre() {Id = 2, Name = "Comedy"},
                new Genre() {Id = 3, Name = "Drama"},
            };
        }

        public async Task<List<Genre>> GetAllGenres()
        {
            await Task.Delay(1000); // 1sec async wait
            return genres;
        }
        public Genre GetGenreById(int Id)
        {
            return genres.FirstOrDefault(x => x.Id == Id); ;
        }

        public void AddGenre(Genre genre)
        {
            genre.Id = genres.Max(x => x.Id) + 1;
            genres.Add(genre);
        }
    }

}
