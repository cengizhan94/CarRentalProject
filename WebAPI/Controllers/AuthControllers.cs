using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;
        private IUserVerifyService _userVerifyService;

        public AuthController(IAuthService authService,IUserVerifyService userVerifyService)
        {
            _authService = authService;
            _userVerifyService = userVerifyService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists);
            }

            var registerResult = _authService.Register(userForRegisterDto);
            
            if (registerResult.Success)
            {
                var userVerify = _userVerifyService.Add(userForRegisterDto.Email);
                var result = _authService.CreateAccessToken(registerResult.Data);
                return Ok(result.Data);
            }

            return BadRequest(registerResult);
        }
    }
}
