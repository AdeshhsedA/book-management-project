using AutoMapper;
using Book__Management_Final.BusinessLogic.DTO.Book;
using Book__Management_Final.BusinessLogic.Services.IServices;
using Book__Management_Final.DataAccess.Models;
using Book__Management_Final.DataAccess.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace Book__Management_Final.BusinessLogic.Services.Services
{
	public class BookServices : IBookServices
	{
		private readonly IBookRepository _bookRepository;
		private readonly IMapper _mapper;

		public BookServices(IBookRepository bookRepository, IMapper mapper)
		{
			_bookRepository = bookRepository;
			_mapper = mapper;
		}
		public string AddBook(BookRequestDTO bookReq)
		{
			if (bookReq.ISBN <= 0)
			{
				return "Invalid ISBN Number";
			}
			if (bookReq.BookShelfNo<=0 || bookReq.ShelfRowNo <= 0)
			{
				return "Invalid Shelf Data";
			}
			if(bookReq.Title.Trim() == "")
			{
				return "Invalid Book Title";
			}
			if(bookReq.AuthorId<=0 || bookReq.SubjectId <= 0)
			{
				return "Invalid Author Id or Subject Id";
			}
			var book = _mapper.Map<Book>(bookReq);
			try
			{
				var res = _bookRepository.InsertBook(book);
				if (res) { return "Success"; }
				return "Failed. Book Already exist.";
			}catch(DbUpdateException due)
			{
				return $"No Author with Id {bookReq.AuthorId} or subject with Id {bookReq.SubjectId} exist. Please add new author or subject...";
			}catch(Exception e)
			{
				return null!;
			}
			
		}

		


		public IEnumerable<BookResDTO> GetAllBooks()
		{
			try
			{
				var res = _bookRepository.GetAll();
				var books = _mapper.Map<IEnumerable<BookResDTO>>(res);
				return books;
			}catch(Exception e)
			{
				return null!;
			}
		}

		public BookResDTO GetBookById(int BookId)
		{
			try
			{
				var res = _bookRepository.GetById(BookId);
				if (res == null)
				{
					return null!;
				}
				var book = _mapper.Map<BookResDTO>(res);
				return book;
			}catch(Exception e)
			{
				return null!;
			}
		}

		public BookResDTO GetBookByISBN(long isbn)
		{
			try
			{
				var res = _bookRepository.GetByISBN(isbn);
				if (res == null)
				{
					return null!;
				}
				var book = _mapper.Map<BookResDTO>(res);
				return book;
			}catch(Exception e)
			{
				return null!;
			}

		}

		public BookResDTO RemoveBook(int BookId)
		{
			try
			{
				var res = _bookRepository.DeleteBook(BookId);
				if (res == null)
				{
					return null!;
				}
				BookResDTO book = _mapper.Map<BookResDTO>(res);
				return book;
			}catch(Exception e)
			{
				return null!;
			}
		}

		public string UpdateBook(int bookId, BookRequestDTO bookReq)
		{
			var book = _mapper.Map<Book>(bookReq);
			try
			{
				var res = _bookRepository.UpdateBook(bookId, book);
				if(res == false) { return "Does Not Exist"; }
				return "Success";
			}
			catch(DbUpdateException due)
			{
				return "Error Author or Subject Doesn't exist. Please Add Author or Subject first";
			}catch(Exception e)
			{
				return null!;
			}
			
		}
	}
}
