namespace Games_Library_Project.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        [Required(ErrorMessage = "Genre has no name.")]
        public string Name { get; set; }
    }
}
