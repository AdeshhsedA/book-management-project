using Book__Management_Final.BusinessLogic.DTO.Author;
using Book__Management_Final.DataAccess.Models;

namespace Book__Management_Final.BusinessLogic.Services.IServices
{
	public interface IAuthorServices
	{
		IEnumerable<Author> GetAllAuthors();
		Author GetAuthorById(int authorId);
		string AddAuthor(AuthorRequestDTO authorReqDTO);
		IEnumerable<Author> GetAuthorByName(string authorName);
	}
}
