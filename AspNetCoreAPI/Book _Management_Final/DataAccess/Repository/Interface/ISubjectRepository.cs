using Book__Management_Final.DataAccess.Models;

namespace Book__Management_Final.DataAccess.Repository.Interface
{
    public interface ISubjectRepository
    {
        IEnumerable<Subject> GetAll();

        Subject GetById(int id);
		IEnumerable<Subject> GetByName(string name);
		Subject Add(Subject subject);
        Subject Update(int id, Subject subject);
        Subject Delete(int id);
    }
}
