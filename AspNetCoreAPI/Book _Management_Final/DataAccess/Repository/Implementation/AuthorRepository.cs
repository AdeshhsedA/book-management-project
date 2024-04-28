using Book__Management_Final.DataAccess.Models;
using Book__Management_Final.DataAccess.Models.Context;
using Book__Management_Final.DataAccess.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Book__Management_Final.DataAccess.Repository.Implementation
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookManagementDbContext _context;

        public AuthorRepository(BookManagementDbContext context)
        {
            _context = context;
        }

        public Author Add(Author author)
        {
            var existAuthor = _context.Authors.FirstOrDefault(a => a.Name == author.Name);
            if (existAuthor != null) { return null!; }
            _context.Authors.Add(author);
            _context.SaveChanges();
            return author;
        }

        public Author Delete(int id)
        {
            var author = GetById(id);
            if (author == null)
            {
                return null!;
            }
            _context.Authors.Remove(author);
            _context.SaveChanges();
            return author;
        }

        public IEnumerable<Author> GetAll()
        {
            return _context.Authors;
        }

        public Author GetById(int id)
        {
            //May return null
            return _context.Authors.FirstOrDefault(a => a.Id == id)!;
        }

        public IEnumerable<Author> GetByName(string name)
        {
            return _context.Authors.Where(a => a.Name.Contains(name));
        }

        public Author Update(int id, Author author)
        {
            var currAuthor = GetById(id);
            if (currAuthor == null) { return null!; }
            currAuthor.Name = author.Name;
            _context.SaveChanges();
            return currAuthor;
        }
    }
}
