using Book__Management_Final.DataAccess.Models;
using Book__Management_Final.DataAccess.Models.Context;
using Book__Management_Final.DataAccess.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Book__Management_Final.DataAccess.Repository.Implementation
{
    public class BookRepository : IBookRepository
    {
        private readonly BookManagementDbContext _context;
        public BookRepository(BookManagementDbContext context)
        {
            _context = context;
        }

        public bool InsertBook(Book book)
        {
            var currBook = _context.Books.FirstOrDefault(b => b.ISBN == book.ISBN);
            if (currBook != null)
            {
                return false;
            }

            _context.Books.Add(book);
            _context.SaveChanges();
            return true;
        }

       

        public Book DeleteBook(int id)
        {
            var book = GetById(id);
            if (book == null)
            {
                return null!;
            }
            _context.Books.Remove(book);
            _context.SaveChanges();
            return book;
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books.Include(b => b.Author).Include(b => b.Subject);
        }

        public Book GetById(int id)
        {
            return _context.Books.Include(b=>b.Author).Include(b=>b.Subject).FirstOrDefault(b => b.Id == id)!;
        }

        public Book GetByISBN(long isbn)
        {
            return _context.Books.Include(b => b.Author).Include(b => b.Subject).FirstOrDefault(b => b.ISBN == isbn)!;
        }



        public void UpdateBookAvailStatus(int bookId)
        {
            var book = GetById(bookId);
            book.IsAvailable = !book.IsAvailable;
            _context.SaveChanges();
        }
        public bool UpdateBook(int id, [FromBody] Book book)
        {
            var currBook = GetById(id);
            if (currBook == null)
            {
                return false;
            }
            currBook.ISBN = book.ISBN;
            currBook.Title = book.Title;
            currBook.Description = book.Description;
            currBook.BookShelfNo = book.BookShelfNo;
            currBook.ShelfRowNo = book.ShelfRowNo;
            currBook.AuthorId = book.AuthorId;
            currBook.SubjectId = book.SubjectId;
            currBook.IsAvailable = book.IsAvailable;
            currBook.ImageUrl = book.ImageUrl;
            _context.SaveChanges();
            return true;
        }


    }
}
