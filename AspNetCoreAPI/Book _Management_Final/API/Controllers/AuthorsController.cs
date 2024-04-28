using Book__Management_Final.BusinessLogic.DTO.Author;
using Book__Management_Final.BusinessLogic.Services.IServices;
using Book__Management_Final.DataAccess.Models;
using Book__Management_Final.DataAccess.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book__Management_Final.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        
        private IAuthorServices _authorServices;
        public AuthorsController( IAuthorServices authorServices)
        {
            
            _authorServices = authorServices;
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public IActionResult GetAllAuthors()
        {
            var result = _authorServices.GetAllAuthors();
            return Ok(result);
        }

        [HttpGet("ByName/{authorName}")]
        [Authorize(Roles ="Admin")]
        public IActionResult GetAuthorsByName(string authorName)
        {
            var result = _authorServices.GetAuthorByName(authorName);
            return Ok(result);
        }

        [HttpGet("{authorId}")]
        [Authorize(Roles ="Admin")]
        public IActionResult GetAuthorById(int authorId)
        {
            var res = _authorServices.GetAuthorById(authorId);
            if(res == null)
            {
                return BadRequest("No Author");
            }
            return Ok(res);
        }

		[HttpPost("addAuthor")]
        [Authorize(Roles ="Admin")]
		public IActionResult AddAuthor(AuthorRequestDTO authorReq)
		{
			var result = _authorServices.AddAuthor(authorReq);
			if (result == "Success")
			{
				return StatusCode(StatusCodes.Status201Created, result);
			}
			return BadRequest(result);
		}
	}
}
