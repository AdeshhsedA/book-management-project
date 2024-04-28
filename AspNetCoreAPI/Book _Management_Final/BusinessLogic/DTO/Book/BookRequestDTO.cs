using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Book__Management_Final.BusinessLogic.DTO.Book
{
    public class BookRequestDTO
    {
        public long ISBN { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int BookShelfNo { get; set; }
        public int ShelfRowNo { get; set; }
        public bool IsAvailable { get; set; }

        public string? ImageUrl { get; set; } = null!;
        public int AuthorId { get; set; }
        public int SubjectId { get; set; }
    }
}
