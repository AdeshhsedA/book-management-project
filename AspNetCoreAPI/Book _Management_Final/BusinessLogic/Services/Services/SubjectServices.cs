using AutoMapper;
using Book__Management_Final.BusinessLogic.DTO.Subject;
using Book__Management_Final.BusinessLogic.Services.IServices;
using Book__Management_Final.DataAccess.Models;
using Book__Management_Final.DataAccess.Repository.Implementation;
using Book__Management_Final.DataAccess.Repository.Interface;

namespace Book__Management_Final.BusinessLogic.Services.Services
{
	public class SubjectServices:ISubjectServices
	{
		private readonly ISubjectRepository _subjectRepository;
		private readonly IMapper _mapper;

		public SubjectServices(ISubjectRepository subjectRepository, IMapper mapper)
		{
			_subjectRepository = subjectRepository;
			_mapper = mapper;
		}
		public string AddSubject(SubjectRequestDTO subjectReqDTO)
		{
			try
			{
				if (subjectReqDTO.Name.Trim() == "") return "Invalid subject Name";
				var subject = _mapper.Map<Subject>(subjectReqDTO);
				var res = _subjectRepository.Add(subject);
				if (res == null) return "Failed. subject Already Exists.";
				return "Success";
			}catch(Exception e)
			{
				return null!;
			}
		}

		public IEnumerable<SubjectResponseDTO> GetAllSubjects()
		{
			try
			{
				var res = _subjectRepository.GetAll();
				var subjects = _mapper.Map<IEnumerable<SubjectResponseDTO>>(res);
				return subjects;
			}catch(Exception e)
			{
				return null!;
			}
		}

		public Subject GetSubjectById(int subjectId)
		{
			try
			{
				var res = _subjectRepository.GetById(subjectId);
				if (res == null)
				{
					return null!;
				}
				return res;
			}catch(Exception e)
			{
				return null!;
			}
		}
		public IEnumerable<Subject> GetSubjectByName(string subjectName)
		{
			try
			{
				var res = _subjectRepository.GetByName(subjectName);
				return res;
			}catch(Exception e)
			{
				return null!;
			}
		}
	}
}
