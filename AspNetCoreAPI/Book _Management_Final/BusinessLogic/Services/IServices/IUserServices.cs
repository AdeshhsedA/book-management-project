using Book__Management_Final.BusinessLogic.DTO.User;

namespace Book__Management_Final.BusinessLogic.Services.IServices
{
	public interface IUserServices
	{

		string LogInUser(UserLoginDTO userLoginDTO);

		bool RegisterUser(UserRegisterDTO userRegisterDTO);
	}
}
