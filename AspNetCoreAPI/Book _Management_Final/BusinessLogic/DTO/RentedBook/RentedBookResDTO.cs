namespace Book__Management_Final.BusinessLogic.DTO.RentedBook
{
	public class RentedBookResDTO
	{
		public int RentId { get; set; }

		public int BookId { get; set; }
		public string BookTitle { get; set; } = null!;
		public string UserName { get; set; } = null!;
		public string UserEmail { get; set; } = null!;
		public string BookImageUrl { get; set; } = null!;
		public string RentedDate { get; set; } = null!;

		public string ReturnedDate { get; set; } = null!;
		public string ExpectedReturnDate { get; set; } = null!;
	}
}
