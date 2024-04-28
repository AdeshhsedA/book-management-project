using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace Book__Management_Final.DataAccess.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password should be 8 char long")]
        public string Password { get; set; } = null!;

        [NotMapped]
        [Compare(nameof(Password), ErrorMessage = "Password doesn't match")]
        public string ConfirmPassword { get; set; } = null!;

        [Required(ErrorMessage = "Contact Information is required")]
        [Range(1111111111, 9999999999, ErrorMessage = "Contact Number should be 10 digit long")]
        public long Contact { get; set; }
        public string Role { get; set; }

        //public ICollection<RentedBook> RentedBooks { get; set; } = null!;

    }
}
