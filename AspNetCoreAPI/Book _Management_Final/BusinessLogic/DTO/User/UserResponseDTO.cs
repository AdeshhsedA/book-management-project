namespace Book__Management_Final.BusinessLogic.DTO.User
{
	public class UserResponseDTO
	{
		public int Id { get; set; }
		public string Email { get; set; } = null!;
		public string Name { get; set; } = null!;
		public long Contact { get; set; }

		public string Role { get; set; } = null!;
	}
}
