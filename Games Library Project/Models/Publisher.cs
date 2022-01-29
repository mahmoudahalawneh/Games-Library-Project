﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Games_Library_Project.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        [Required(ErrorMessage = "The publisher has no name.")]
        public string ? Name { get; set; }
        [Required(ErrorMessage = "The publisher has no starting year.")]
        [Range(1958, 2026, ErrorMessage = "The publisher's starting Year must be in range of [1958,2026].")]
        public int Year { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

    }
}
