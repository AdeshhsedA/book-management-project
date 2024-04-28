using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book__Management_Final.DataAccess.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "ISBN is required")]
        public long ISBN { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Book Shelf Number is required")]
        [Range(1, 300, ErrorMessage = "Book Shelf Number should be greater than 0 and less than 300")]
        public int BookShelfNo { get; set; }

        [Required(ErrorMessage = "Shelf Row Number is required")]
        [Range(1, 10, ErrorMessage = "Shelf Row Number should be greater than 0 and less than 11")]
        public int ShelfRowNo { get; set; }

        [Required(ErrorMessage = "Availability status is required")]
        public bool IsAvailable { get; set; }

        //[Required(ErrorMessage = "Image Url is required")]
        public string? ImageUrl { get; set; } = null!;

        //Navigation Properties
        //Author
        [ForeignKey(nameof(AuthorId))]
        public int AuthorId { get; set; }

        public Author Author { get; set; } 

        //Subject
        [ForeignKey(nameof(SubjectId))]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public ICollection<RentedBook> RentedBooks { get; set; } = null!;
    }
}