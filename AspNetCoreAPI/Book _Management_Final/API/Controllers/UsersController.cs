using Book__Management_Final.BusinessLogic.DTO.User;
using Book__Management_Final.BusinessLogic.Services.IServices;
using Book__Management_Final.DataAccess.Models;
using Book__Management_Final.DataAccess.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Book__Management_Final.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //private readonly IUserRepository _userRepository;
        private readonly IUserServices _userServices;
        public UsersController( IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public IActionResult Login(UserLoginDTO userLoginDTO)
        {
            if(userLoginDTO.Email.Trim()=="" || userLoginDTO.Password.Trim() == "")
            {
                return BadRequest("Invalid User Data");
            }
            var res = _userServices.LogInUser(userLoginDTO);
            if(res == null) { return NotFound(); }
            return Ok(res);
        }

        [HttpPost("Register")]
		[AllowAnonymous]
		public IActionResult Register(UserRegisterDTO userReq)
        {
            var result = _userServices.RegisterUser(userReq);
            if (result == false)
            {
                return BadRequest($"User with email {userReq.Email} already exists");
            }

            return StatusCode(StatusCodes.Status201Created, result);
        }
    }
}
