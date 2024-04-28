using AutoMapper;
using Book__Management_Final.BusinessLogic.DTO.Author;
using Book__Management_Final.BusinessLogic.Services.IServices;
using Book__Management_Final.DataAccess.Models;
using Book__Management_Final.DataAccess.Repository.Interface;

namespace Book__Management_Final.BusinessLogic.Services.Services
{
	public class AuthorServices : IAuthorServices
	{
		private readonly IAuthorRepository _authorRepository;
		private readonly IMapper _mapper;

		public AuthorServices(IAuthorRepository authorRepository, IMapper mapper)
		{
			_authorRepository = authorRepository;
			_mapper = mapper;
		}
		public string AddAuthor(AuthorRequestDTO authorReqDTO)
		{
			try
			{
				if (authorReqDTO.Name.Trim() == "") return "Invalid Author Name";
				var author = _mapper.Map<Author>(authorReqDTO);
				var res = _authorRepository.Add(author);
				if (res == null) return "Failed. Author Already Exists.";
				return "Success";
			}catch(Exception e)
			{
				return null!;
			}
		}

		public IEnumerable<Author> GetAllAuthors()
		{
			try
			{
				var res = _authorRepository.GetAll().ToList();
				return res;
			}catch(Exception e)
			{
				return null!;
			}
		}

		public Author GetAuthorById(int authorId)
		{
			try
			{
				var res = _authorRepository.GetById(authorId);
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

		public IEnumerable<Author> GetAuthorByName(string authorName)
		{
			try
			{
				var res = _authorRepository.GetByName(authorName);
				return res;
			}catch(Exception e)
			{
				return null!;
			}
		}
	}
}
