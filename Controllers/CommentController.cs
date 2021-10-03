using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Backend.DTOs;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/comment/")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _service;
        public CommentController(ICommentService service)
        {
            _service = service;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddComment([FromBody] CommentForAddDTO comment)
        {
            var userID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            await _service.AddComment(comment, userID);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveComment(int id)
        {
            await _service.RemoveComment(id);
            return Ok();
        }


        [HttpGet("getByMovie/{id}")]
        public async Task<ActionResult<IEnumerable<CommentForReturnDTO>>> GetCommentsByMovie(int id)
        {
            return Ok(await _service.GetMovieComments(id));
        }

        [HttpGet("getByUser")]
        public async Task<ActionResult<IEnumerable<CommentForReturnDTO>>> GetCommentsByUser()
        {
            var userID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return Ok(await _service.GetUserComments(userID));
        }
    }
}