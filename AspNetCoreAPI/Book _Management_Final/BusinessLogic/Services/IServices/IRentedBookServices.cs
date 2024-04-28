using Book__Management_Final.BusinessLogic.DTO.RentedBook;

namespace Book__Management_Final.BusinessLogic.Services.IServices
{
	public interface IRentedBookServices
	{
		IEnumerable<RentedBookResDTO> GetAllRentedBooks();
		IEnumerable<RentedBookResDTO> GetCurrentRentedBooks();

		IEnumerable<RentedBookResDTO> GetBookRentedByUser(int userId);
		IEnumerable<RentedBookResDTO> GetDeletedRentedBooksDetails();


		IEnumerable<RentedBookResDTO> GetReturnedBooks();
		string RentNewBook(int bookId, int userId);

		string ReturnRentedBook(int bookId, int userId);

		string DeleteRentedBook(int rentId, int userId);

	}
}
