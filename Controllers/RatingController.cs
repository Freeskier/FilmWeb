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
    [Route("api/rating/")]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _service;
        public RatingController(IRatingService service)
        {
            _service = service;

        }
        [HttpPost("add")]
        public async Task<IActionResult> AddRating([FromBody] RatingForAddDTO rating)
        {
            var userID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            await _service.AddRating(rating, userID);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveRating(int id)
        {
            await _service.RemoveRating(id);
            return Ok();
        }


        [HttpGet("getByMovie/{id}")]
        public async Task<ActionResult<IEnumerable<RatingForReturnDTO>>> GetRatingsByMovie(int id)
        {
            return Ok(await _service.GetMovieRatings(id));
        }
    }
}