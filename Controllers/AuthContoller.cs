using System;
using System.Threading.Tasks;
using Backend.DTOs;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/auth/")]
    public class AuthContoller : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthContoller(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDTO user)
        {
            try
            {
                return Ok(await _authService.RegisterAsync(user));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost("login")]
        public async Task <IActionResult> Login([FromBody] UserForLoginDTO user)
        {
            try
            {
                return Ok(await _authService.LoginAsync(user));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}