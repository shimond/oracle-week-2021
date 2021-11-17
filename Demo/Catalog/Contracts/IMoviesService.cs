using Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Contracts
{
    public interface IMoviesService
    {
        Task<List<Movie>> GetAll();
        Task<Movie> GetById(int movieId);
        Task<Movie> AddMovie(Movie movie);
        Task<Movie> DeleteMovieItem(int movieId);
        Task<Movie> UpdateMovie(Movie movie);
    }
}
