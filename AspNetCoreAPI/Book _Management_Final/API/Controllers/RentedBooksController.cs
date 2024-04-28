using Book__Management_Final.BusinessLogic.Services.IServices;
using Book__Management_Final.DataAccess.Models;
using Book__Management_Final.DataAccess.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Security.Claims;

namespace Book__Management_Final.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentedBooksController : ControllerBase
    {
        private IRentedBookServices _rentedBookServices;
        public RentedBooksController(IRentedBookServices rentedBookServices)
        {
            _rentedBookServices = rentedBookServices;
        }

        [HttpGet("NotReturned")]
        [Authorize(Roles ="Admin")]
        public IActionResult GetCurrentRentedBookList()
        {
            var result = _rentedBookServices.GetCurrentRentedBooks();
            return Ok(result);
        }

        [HttpGet("Deleted")]
        [Authorize(Roles ="Admin")]
        public IActionResult GetDeletedRentedBookList()
        {
            var result = _rentedBookServices.GetDeletedRentedBooksDetails();

            return Ok(result);
        }

        [HttpGet("Returned")]
        [Authorize(Roles ="Admin")]
        public IActionResult GetReturnedBookList()
        {
            var result = _rentedBookServices.GetReturnedBooks();
            
            return Ok(result);
        }


		//Return rent details of all books rented by a user
		[HttpGet("UserRentedDetails")]
        [Authorize(Roles ="User")]
		public IActionResult GetUserRentDetails()
		{
            int userId = int.Parse(HttpContext.User.FindFirst("Id")?.Value);
			var result = _rentedBookServices.GetBookRentedByUser(userId);
			return Ok(result);
		}


		[HttpPost("rentbook/{bookId}")]
        [Authorize(Roles ="User")]
        public IActionResult RentBook(int bookId)
        {
            if (bookId <= 0) return BadRequest("Invalid Book Id");
            int userId = int.Parse(HttpContext.User.FindFirst("Id")?.Value);

			var res = _rentedBookServices.RentNewBook(bookId, userId);
            

            if (res == "Success") return StatusCode(StatusCodes.Status201Created, res);
            return BadRequest(res);

        }



        [HttpPost("returnBook/{bookId}")]
        [Authorize(Roles ="User")]
        public IActionResult ReturnBook(int bookId)
        {
            //verify user details first
            int userId = int.Parse(HttpContext.User.FindFirstValue("Id"));
            if (bookId <= 0)
            {
                return BadRequest("Invalid Book Id");
            }

            var rentedBook = _rentedBookServices.ReturnRentedBook(bookId, userId);
            if (rentedBook == "Success")
            {
                return Ok("Book Returned");
            }
            return BadRequest(rentedBook);
        }

		//Delete only when book is returned
		[HttpDelete("DeleteRentedDetails/{rentId}")]
        [Authorize(Roles = "User")]
		public IActionResult DeleteRentedDetail(int rentId)
		{
			int userId = int.Parse(HttpContext.User.FindFirstValue("Id"));
			var res = _rentedBookServices.DeleteRentedBook(rentId, userId);
			if (res == "Success") return Ok(res);
			if (res == "Not Exists") return NotFound("Not Exist");
			return BadRequest(res);
		}

	}
}
