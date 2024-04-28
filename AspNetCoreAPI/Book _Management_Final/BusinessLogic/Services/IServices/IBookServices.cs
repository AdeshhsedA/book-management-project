using Book__Management_Final.BusinessLogic.DTO.Book;
using Book__Management_Final.DataAccess.Models;
using Book__Management_Final.DataAccess.Repository.Interface;

namespace Book__Management_Final.BusinessLogic.Services.IServices
{
	public interface IBookServices
	{
		IEnumerable<BookResDTO> GetAllBooks();

		BookResDTO GetBookById(int BookId);

		BookResDTO GetBookByISBN(long isbn);

		string AddBook(BookRequestDTO bookReq);


		BookResDTO RemoveBook(int BookId);

		string UpdateBook(int bookId, BookRequestDTO book);
	}
}
