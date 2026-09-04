using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entity;
using ApplicationCore.Model;

namespace ApplicationCore.Contracts.Services
{
    public interface IMovieService
    {
        IEnumerable<MovieCardModel> GetTopGrossingMovieCards();
    }
}
