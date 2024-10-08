﻿using System.ComponentModel.DataAnnotations;

namespace Games_Library_Project.Models
{
    public class Game
    {
        public int GameId { get; set; }
        [Required(ErrorMessage = "The game has no name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The game has no publisher.")]
        public Publisher PublisherComp { get; set; }
        [Required(ErrorMessage = "The game has no release year.")]
        [Range(1958, 2026, ErrorMessage = "The game's Year must be in range of [1958,2026].")]
        public int Year { get; set; }
        [Required]
        public Genre type { get; set; }
        public string? Available { get; set; }
    }
}
