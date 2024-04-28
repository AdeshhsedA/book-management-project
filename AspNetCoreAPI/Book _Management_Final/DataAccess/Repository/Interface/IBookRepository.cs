using Book__Management_Final.DataAccess.Models;

namespace Book__Management_Final.DataAccess.Repository.Interface
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();

        Book GetById(int id);
        Book GetByISBN(long isbn);
        void UpdateBookAvailStatus(int bookId);

        bool InsertBook(Book book);

        bool UpdateBook(int id, Book book);

        Book DeleteBook(int id);

    }
}
