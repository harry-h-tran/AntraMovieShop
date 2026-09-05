using ApplicationCore.Model;

namespace ApplicationCore.Contracts.Services
{
    public interface IGenreService
    {
        IEnumerable<GenreModel> GetAll();

    }
}
