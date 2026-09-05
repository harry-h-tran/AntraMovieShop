using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entity;
using ApplicationCore.Model;

namespace Infrastructure.Services
{
    public class GenreService : IGenreService
    {
        private readonly IRepository<Genre> _genreRepository;

        public GenreService(IRepository<Genre> genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public IEnumerable<GenreModel> GetAll()
        {
            var genres = _genreRepository.GetAll();
            return genres.Select(g => new GenreModel
            {
                Id = g.Id,
                Name = g.Name
            });
        }
    }
}
