using first_web_app.Contracts;
using first_web_app.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace first_web_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }


        [HttpGet(Name = "GetAllMovies")]
        public async Task<ActionResult<List<Movie>>> GetAll()
        {
            var result = await _moviesService.GetAll();
            return Ok(result);
        }

        [HttpPost(Name = nameof(AddNewMovie))]
        public async Task<ActionResult<List<Movie>>> AddNewMovie(Movie m)
        {
            var result = await _moviesService.AddMovie(m);
            return Ok(result);
        }

    }
}
