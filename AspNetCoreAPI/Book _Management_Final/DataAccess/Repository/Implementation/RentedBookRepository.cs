using Book__Management_Final.DataAccess.Models;
using Book__Management_Final.DataAccess.Models.Context;
using Book__Management_Final.DataAccess.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Book__Management_Final.DataAccess.Repository.Implementation
{
    public class RentedBookRepository : IRentedBookRepository
    {
        private readonly BookManagementDbContext _context;
        public RentedBookRepository(BookManagementDbContext context)
        {
            _context = context;
        }

        public RentedBook Add(RentedBook rentedBook)
        {
            var existRent = GetByBookId(rentedBook.BookId);
            if (existRent != null) { return null!; }
            _context.RentedBooks.Add(rentedBook);
            _context.SaveChanges();
            return rentedBook;
        }

        public RentedBook GetByRentId(int rentId)
        {
            return _context.RentedBooks.FirstOrDefault(rb=>rb.RentId == rentId && rb.IsDeleted==false)!;
        }


        public RentedBook Delete(int RentId)
        {
            var rentedBook = _context.RentedBooks.FirstOrDefault(rb => rb.RentId == RentId);
            if (rentedBook == null) { return null!; }
            _context.RentedBooks.Remove(rentedBook);

            _context.SaveChanges();
            return rentedBook;
        }

        public IEnumerable<RentedBook> GetAllForUserId(int userId)
        {
            return _context.RentedBooks.Include(rb => rb.Book).Include(rb => rb.User).Where(rb => rb.UserId == userId && rb.ReturnedDate==null);
        }

        //Admin only access
        public IEnumerable<RentedBook> GetAll()
        {
            return _context.RentedBooks.Include(rb=>rb.Book).Include(rb=>rb.User);
        }

        public RentedBook GetByBookId(int bookId)
        {
            //May return null
            return _context.RentedBooks.FirstOrDefault(rb => rb.BookId == bookId && rb.ReturnedDate == null)!;
        }

        public RentedBook Update(int bookId, RentedBook rentedBook)
        {
            var currRentedBook = GetByBookId(bookId);
            if (currRentedBook == null) { return null!; }
            currRentedBook.RentedDate = rentedBook.RentedDate;
            currRentedBook.ExpectedReturnDate = rentedBook.ExpectedReturnDate;
            currRentedBook.UserId = rentedBook.UserId;
            currRentedBook.BookId = bookId;
            currRentedBook.ReturnedDate = rentedBook.ReturnedDate;
            currRentedBook.IsDeleted = rentedBook.IsDeleted;
            _context.SaveChanges();
            return currRentedBook;
        }
    }
}
