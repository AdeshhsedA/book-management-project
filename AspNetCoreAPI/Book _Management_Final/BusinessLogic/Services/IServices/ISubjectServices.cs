using Book__Management_Final.BusinessLogic.DTO.Subject;
using Book__Management_Final.DataAccess.Models;

namespace Book__Management_Final.BusinessLogic.Services.IServices
{
	public interface ISubjectServices
	{
		IEnumerable<SubjectResponseDTO> GetAllSubjects();
		Subject GetSubjectById(int subjectId);
		string AddSubject(SubjectRequestDTO subjectReqDTO);
		IEnumerable<Subject> GetSubjectByName(string subjectName);
	}
}
