using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Book__Management_Final.DataAccess.Models
{

    public class RentedBook
    {
        [Key]
        public int RentId { get; set; }
        [ForeignKey(nameof(BookId))]

        public int BookId { get; set; }
        public Book Book { get; set; } = null!;
        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public string RentedDate { get; set; } = null!;
        public string ExpectedReturnDate { get; set; } = null!;
        public string? ReturnedDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}
