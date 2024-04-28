using Book__Management_Final.DataAccess.Models;

namespace Book__Management_Final.DataAccess.Repository.Interface
{
    public interface IUserRepository
    {
        //Get Add Update
        User Get(string email, string password);
        bool InsertUser(User user);
        bool UpdateUser(string email, User user);

    }
}
