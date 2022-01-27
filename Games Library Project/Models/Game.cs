using System.ComponentModel.DataAnnotations;

namespace Games_Library_Project.Models
{
    public class Game
    {
        public int GameId { get; set; }
        [Required(ErrorMessage = "The game has no name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The game has no publisher.")]
        public Publisher Publisher { get; set; }
        [Required(ErrorMessage = "The game has no release year.")]
        [Range(1958, 2026, ErrorMessage = "The game's Year must be in range of [1958,2026].")]
        public int PublisherId { get; set; }
        public int Year { get; set; }
        [Required]
        public Genre Genre { get; set; }
        public string GenreId { get; set; }

        public string Available { get; set; }
        [Required(ErrorMessage = "The game has no price.")]
        public string Price { get; set; }
        public string StoreLink { get; set; }
        public string ImgLink { get; set; }
    }
}
