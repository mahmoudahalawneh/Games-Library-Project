using System.ComponentModel.DataAnnotations;

namespace Games_Library_Project.Models
{
    public class Genre
    {
        public string GenreId { get; set; }
        [Required(ErrorMessage = "Genre has no name.")]
        public string Name { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
    }
}
