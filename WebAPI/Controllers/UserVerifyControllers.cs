using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserVeryfiesController : ControllerBase
    {
        private IUserVerifyService _userVerifyService;
        private IUserService _userService;
        public UserVeryfiesController(IUserVerifyService userVerifyService, IUserService userService)
        {
            _userVerifyService = userVerifyService;
            _userService = userService;
        }

        [HttpGet("verify")]
        public IActionResult Verify(string verifyToken)
        {
            var verifyResult = _userVerifyService.Verify(verifyToken);
            if (verifyResult.Success)
            {
                var userVerify = _userVerifyService.GetByVerifyToken(verifyToken);
                var updatedUser = _userService.GetById(userVerify.UserId);
                updatedUser.Status = true;
                _userService.Update(updatedUser);
                return Ok(verifyResult);
            }
            return BadRequest(verifyResult);
        }
    }
}
