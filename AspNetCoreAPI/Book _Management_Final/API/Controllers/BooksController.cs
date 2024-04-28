using Book__Management_Final.BusinessLogic.DTO.Book;
using Book__Management_Final.BusinessLogic.Services.IServices;
using Book__Management_Final.DataAccess.Models;
using Book__Management_Final.DataAccess.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace Book__Management_Final.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookServices _bookServices;
        private IWebHostEnvironment _hostEnvironemt;

        public BooksController(IBookServices bookServices, IWebHostEnvironment hostEnvironment)
        {
            _bookServices = bookServices;
            _hostEnvironemt = hostEnvironment;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAllBooks()
        {
            var result = _bookServices.GetAllBooks();
            return Ok(result);
        }

        [HttpGet("{bookId}")]
        [Authorize]
        public IActionResult GetBookById(int bookId)
        {
            var result = _bookServices.GetBookById(bookId);
            if (result == null)
            {
                return NotFound($"No Book Id {bookId} exists in library");
            }
            return Ok(result);
        }


        [HttpGet("isbn/{isbn}")]
        [Authorize]
        public IActionResult GetBookByISBN(long isbn)
        {
            var result = _bookServices.GetBookByISBN(isbn);
            if (result == null)
            {
                return NotFound($"No book with ISBN {isbn} exists in library");
            }
            return Ok(result);
        }

        [HttpPost("AddBook")]
        [Authorize(Roles ="Admin")]
        public IActionResult AddBook(BookRequestDTO bookReq)
        {
            var result = _bookServices.AddBook(bookReq);
			if (result == "Success")
			{
				return StatusCode(StatusCodes.Status201Created, result);
			}
			return BadRequest(result);
            
        }

        [HttpPost("uploadFile")]
        public IActionResult UploadImage(IFormFile file)
		{
			try
            {
				
				if (file.Length > 0)
				{

					//var fullPath = Path.Combine(pathToSave, file.FileName);
					//var dbPath = Path.Combine(folderName, file.FileName);
					var filePath = Path.Combine(_hostEnvironemt.WebRootPath, "Images", file.FileName);
                    var dbPath = "/Images/" + file.FileName;

					using (var stream = new FileStream(filePath, FileMode.Create))
					{
						file.CopyTo(stream);
					}
				    return Ok(dbPath);
				}

				return NotFound();
			}
			catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        
        [HttpPut("{bookId}")]
        [Authorize(Roles ="Admin")]
        public IActionResult UpdateBook(int bookId, BookRequestDTO bookReq)
        {
            var result = _bookServices.UpdateBook(bookId, bookReq);
            if (result == "Does Not Exist")
            {
                return NotFound($"No Book with Id {bookId} exists in library");
            }
            if(result == "Success")
            {
                return Ok("Success...");
            }

            return BadRequest(result);

        }


		[HttpDelete("{bookId}")]
        [Authorize(Roles ="Admin")]
		public IActionResult RemoveBook(int bookId)
		{
			var result = _bookServices.RemoveBook(bookId);
			if (result == null)
			{
				return NotFound($"No Book with Id {bookId} exists");
			}
			return Ok(result);
		}



	}
}
