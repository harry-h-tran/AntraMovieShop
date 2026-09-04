using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entity;

namespace ApplicationCore.Contracts.Repository
{
    public interface IMovieRepository: IRepository<Movie>
    {
        public IEnumerable<Movie> GetTop30GrossingMovies();
    }
}
