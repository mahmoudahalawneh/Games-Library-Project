using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Games_Library_Project.Models
{
    public class Genre
    {
        public string GenreId { get; set; }
        [Required(ErrorMessage = "Genre has no name.")]
        public string Name { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}
