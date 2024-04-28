using AutoMapper;
using Book__Management_Final.BusinessLogic.DTO.Author;
using Book__Management_Final.BusinessLogic.DTO.Book;
using Book__Management_Final.BusinessLogic.DTO.RentedBook;
using Book__Management_Final.BusinessLogic.DTO.Subject;
using Book__Management_Final.BusinessLogic.DTO.User;
using Book__Management_Final.DataAccess.Models;


namespace Book__Management_Final.BusinessLogic.Mappings
{
	public class MapperConfig:Profile
	{
		public MapperConfig()
		{
			CreateMap<UserResponseDTO, User>().ReverseMap();

			CreateMap<UserRegisterDTO, User>().ReverseMap();

			//Book DTO Mappers

			CreateMap<BookResDTO, Book>().ReverseMap();
			CreateMap<BookRequestDTO, Book>().ReverseMap();

			//Auhtor DTO Mapper Config
			CreateMap<AuthorRequestDTO, Author>().ReverseMap();

			//Subject DTO Mapper Config
			CreateMap<SubjectRequestDTO, Subject>().ReverseMap();
			CreateMap<SubjectResponseDTO, Subject>().ReverseMap();

			//Rented Book DTO Mapper Config
			CreateMap<RentedBookResDTO, RentedBook>().ReverseMap();
		}
	}
}
