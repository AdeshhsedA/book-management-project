using Book__Management_Final.DataAccess.Models;

namespace Book__Management_Final.DataAccess.Repository.Interface
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAll();

        Author GetById(int id);
        IEnumerable<Author> GetByName(string name);

		Author Add(Author author);
        Author Update(int id, Author author);
        Author Delete(int id);
    }
}
