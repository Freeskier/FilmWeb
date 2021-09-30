using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Backend.DTOs;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/movie/")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _service;
        public MovieController(IMovieService service)
        {
            _service = service;

        }

        [HttpPost("add")]
        public async Task<IActionResult> AddMovie([FromBody] MovieForAddDTO movie)
        {
            await _service.AddMovie(movie);
            return Ok();
        }

        [HttpPost("addSeen/{movieID}")]
        public async Task<IActionResult> AddSeenMovie(int movieID)
        {
            var userID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            await _service.AddToSeen(movieID, userID);
            return Ok();
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetAllMovies()
        {
            return Ok(await _service.GetAllMovies());
        }

        [HttpGet("get/{movieID}")]
        public async Task<ActionResult<Movie>> GetAllMovies(int movieID)
        {
            return Ok(await _service.GetMovie(movieID));
        }

        [HttpGet("getSeen")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetSeen()
        {
            var userID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return Ok(await _service.GetSeen(userID));
        }
    }
}