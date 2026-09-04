using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entity;

namespace ApplicationCore.Contracts.Services
{
    public interface IGenreService
    {
        IEnumerable<Genre> GetAll();

    }
}
