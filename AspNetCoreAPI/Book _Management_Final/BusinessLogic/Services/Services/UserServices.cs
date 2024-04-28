using AutoMapper;
using Book__Management_Final.BusinessLogic.DTO.User;
using Book__Management_Final.BusinessLogic.Services.IServices;
using Book__Management_Final.DataAccess.Models;
using Book__Management_Final.DataAccess.Models.Context;
using Book__Management_Final.DataAccess.Repository.Interface;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Book__Management_Final.BusinessLogic.Services.Services
{
	public class UserServices : IUserServices
	{
		private readonly IUserRepository _userRepository;
		private readonly IConfiguration _config;
		private readonly IMapper _mapper;
		public UserServices(IUserRepository userRepository, IMapper mapper, IConfiguration config) {
			_userRepository = userRepository;
			_mapper = mapper;
			_config = config;
		}	
		public string LogInUser(UserLoginDTO userLoginDTO)
		{
			
			try
			{
				
				var res = _userRepository.Get(userLoginDTO.Email, userLoginDTO.Password);
				if(res == null)
				{
					return null!;
				}

				var user = _mapper.Map<UserResponseDTO>(res);
				var token = GenerateJwtToken(user);
				return token;


			}
			catch (InvalidDataException ide)
			{
				return null!;
			}catch(Exception e)
			{
				return null!;
			}

		}

		public string GenerateJwtToken(UserResponseDTO userResDto)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var claims = new[]
			{
				new Claim("Id",userResDto.Id.ToString()),
				new Claim(ClaimTypes.Email , userResDto.Email),
				new Claim(ClaimTypes.Name , userResDto.Name),
				new Claim(ClaimTypes.Role, userResDto.Role)
			};

			var token = new JwtSecurityToken(
				issuer:_config["JWT:Issuer"],
				audience:_config["JWT:Audience"],
				claims:claims,
				expires:DateTime.Now.AddMinutes(60),
				signingCredentials:credentials
				);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		public bool RegisterUser(UserRegisterDTO userRegisterDTO)
		{
			try
			{
				var user = _mapper.Map<User>(userRegisterDTO);
				var res = _userRepository.InsertUser(user);
				return res;
			}catch(Exception e)
			{
				return false;
			}
		}
	}
}
