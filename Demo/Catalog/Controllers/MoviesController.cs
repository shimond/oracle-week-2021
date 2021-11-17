using Catalog.Contracts;
using Catalog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }


        [HttpGet("GetOs")]
        public async Task<IActionResult> GetOS()
        {
            await Task.Delay(10);
            var result = Environment.OSVersion;
            return Ok(result);
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
