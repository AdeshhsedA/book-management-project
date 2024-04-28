using Book__Management_Final.DataAccess.Models;
using Book__Management_Final.DataAccess.Models.Context;
using Book__Management_Final.DataAccess.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Book__Management_Final.DataAccess.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly BookManagementDbContext _context;
        public UserRepository(BookManagementDbContext context)
        {
            _context = context;
        }

        public User Get(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u =>
            u.Email == email && EF.Functions.Collate(u.Password, "SQL_Latin1_General_CP1_CS_AS") == password);
            return user!;
        }

        public bool UserExists(string Email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == Email);
            if (user == null) return false;
            return true;
        }

        public bool InsertUser(User user)
        {
            if (UserExists(user.Email)) return false;
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateUser(string email, User user)
        {
            var currUser = _context.Users.FirstOrDefault(u => u.Email == email);
            if (currUser == null) return false;
            currUser.Name = user.Name;
            currUser.Email = user.Email;
            currUser.Password = user.Password;
            _context.SaveChanges();
            return true;

        }
    }
}
