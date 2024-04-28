using Book__Management_Final.DataAccess.Models;

namespace Book__Management_Final.DataAccess.Repository.Interface
{
    public interface IRentedBookRepository
    {
        IEnumerable<RentedBook> GetAllForUserId(int userId);
        RentedBook GetByBookId(int bookId);

        RentedBook GetByRentId(int rentId);

        RentedBook Add(RentedBook rentedBook);
        IEnumerable<RentedBook> GetAll();

        RentedBook Update(int bookId, RentedBook rentedBook);
        RentedBook Delete(int RentId);
    }
}
