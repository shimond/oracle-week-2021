using first_web_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace first_web_app.Contracts
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
