using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsModule.Business.Interfaces;
using NewsModule.DTOs.UserDtos;

namespace NewsModule.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            return Ok(await _userService.Login(loginDto));
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            return Ok(await _userService.Register(registerDto));
        }
    }
}
