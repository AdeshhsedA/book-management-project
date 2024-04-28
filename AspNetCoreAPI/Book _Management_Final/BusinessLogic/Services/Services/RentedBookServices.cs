using AutoMapper;
using Book__Management_Final.BusinessLogic.DTO.RentedBook;
using Book__Management_Final.BusinessLogic.Services.IServices;
using Book__Management_Final.DataAccess.Models;
using Book__Management_Final.DataAccess.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Book__Management_Final.BusinessLogic.Services.Services
{
	public class RentedBookServices : IRentedBookServices
	{
		private readonly IRentedBookRepository _rentedBookRepository;
		private readonly IBookRepository _bookRepository;
		private readonly IMapper _mapper;

		public RentedBookServices(IRentedBookRepository rentedBookRepository,IBookRepository bookRepository ,IMapper mapper)
		{
			_rentedBookRepository = rentedBookRepository;
			_bookRepository = bookRepository;
			_mapper = mapper;
		}
		public string DeleteRentedBook(int rentId, int userId)
		{
			try
			{
				var rentedBook = _rentedBookRepository.GetByRentId(rentId);
				if (rentedBook == null) return "Not Exists";
				if (rentedBook.UserId != userId) { return $"User Does not have any rent record with Id {rentId}"; }
				if (rentedBook.ReturnedDate == null) { return $"Please Return the book first"; }
				rentedBook.IsDeleted = true;
				_rentedBookRepository.Update(rentedBook.BookId, rentedBook);
				return "Success";
			}catch(Exception e)
			{
				return null!;
			}
		}

		public IEnumerable<RentedBookResDTO> GetAllRentedBooks()
		{
			try
			{
				var res = _rentedBookRepository.GetAll();
				var rentedBooks = _mapper.Map<IEnumerable<RentedBookResDTO>>(res);
				return rentedBooks;
			}catch(Exception e)
			{
				return null!;
			}
		}

		public IEnumerable<RentedBookResDTO> GetBookRentedByUser(int userId)
		{
			try
			{
				var res = _rentedBookRepository.GetAllForUserId(userId);
				var rentedBooks = _mapper.Map<IEnumerable<RentedBookResDTO>>(res);
				return rentedBooks;
			}catch(Exception e)
			{
				return null!;
			}
		}

		public IEnumerable<RentedBookResDTO> GetCurrentRentedBooks()
		{
			try
			{
				var res = _rentedBookRepository.GetAll().Where(rb => rb.ReturnedDate == null);
				var rentedBooks = _mapper.Map<IEnumerable<RentedBookResDTO>>(res);
				return rentedBooks;
			}catch(Exception e)
			{
				return null!;
			}

		}

		public IEnumerable<RentedBookResDTO> GetReturnedBooks()
		{
			try
			{
				var res = _rentedBookRepository.GetAll().Where(rb => rb.ReturnedDate != null && rb.IsDeleted == false);
				var rentedBooks = _mapper.Map<IEnumerable<RentedBookResDTO>>(res);
				return rentedBooks;
			}catch(Exception e)
			{
				return null!;
			}
		}

		public IEnumerable<RentedBookResDTO> GetDeletedRentedBooksDetails()
		{
			try
			{
				var res = _rentedBookRepository.GetAll().Where(rb => rb.IsDeleted == true);
				var rentedBooks = _mapper.Map<IEnumerable<RentedBookResDTO>>(res);
				return rentedBooks;
			}catch(Exception e)
			{
				return null!;
			}
		}

		public string RentNewBook(int bookId, int userId)
		{
			
			try
			{
				var book = _bookRepository.GetById(bookId);
				if(book == null) { return "Book Doesn't Exist"; }
				if(book.IsAvailable == false) {return "Book Is Not Available for Rent."; }
				RentedBook rentedBook = new RentedBook()
				{
					BookId = bookId,
					UserId = userId,
					RentedDate = DateTime.Now.ToString("yyyy-MM-dd"),
					ExpectedReturnDate = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd")
				};
				var res = _rentedBookRepository.Add(rentedBook);
				Console.WriteLine(res);
				if (res == null)
				{
					return "Book Is Not Avaiable For Rent.";
				}
				_bookRepository.UpdateBookAvailStatus(book.Id);
				return "Success";
			}catch(DbUpdateException due)
			{
				return $"Failed Book with {bookId} doesn't exist";
			}catch(Exception e)
			{
				return null!;
			}
		}

		public string ReturnRentedBook(int bookId, int userId)
		{
			try
			{
				var book = _bookRepository.GetById(bookId);
				if (book == null) { return "Book Doesn't Exist"; }
				var rentedBook = _rentedBookRepository.GetByBookId(bookId);
				if (rentedBook == null || rentedBook.UserId != userId)
				{
					return $"User does not rent a book with Id {bookId}";
				}
				rentedBook.ReturnedDate = DateTime.Now.ToString("yyyy-MM-dd");
				_bookRepository.UpdateBookAvailStatus(book.Id);
				_rentedBookRepository.Update(rentedBook.BookId, rentedBook);
				return "Success";
			}catch(Exception e)
			{
				return null!;
			}
		}
	}
}
