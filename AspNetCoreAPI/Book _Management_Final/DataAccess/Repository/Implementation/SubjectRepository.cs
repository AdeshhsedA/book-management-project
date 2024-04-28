using Book__Management_Final.DataAccess.Models;
using Book__Management_Final.DataAccess.Models.Context;
using Book__Management_Final.DataAccess.Repository.Interface;

namespace Book__Management_Final.DataAccess.Repository.Implementation
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly BookManagementDbContext _context;
        public SubjectRepository(BookManagementDbContext context)
        {
            _context = context;
        }
        public Subject Add(Subject subject)
        {
            var existSubject = _context.Subjects.FirstOrDefault(s => s.Name == subject.Name);
            if (existSubject != null) { return null!; }
            _context.Subjects.Add(subject);
            _context.SaveChanges();
            return subject;
        }

        public Subject Delete(int id)
        {
            var subject = GetById(id);
            if (subject == null) { return null!; }
            _context.Subjects.Remove(subject);
            _context.SaveChanges();
            return subject;
        }

        public IEnumerable<Subject> GetAll()
        {
            return _context.Subjects.ToList();
        }

        public Subject GetById(int id)
        {
            //May be null
            return _context.Subjects.FirstOrDefault(s => s.Id == id)!;
        }

		public IEnumerable<Subject> GetByName(string name)
		{
			return _context.Subjects.Where(a => a.Name.Contains(name));
		}

		public Subject Update(int id, Subject subject)
        {
            var result = GetById(id);
            if (result == null)
            {
                return null!;
            }

            result.Name = subject.Name;
            _context.SaveChanges();
            return result;
        }
    }
}
