using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Games_Library_Project.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required (ErrorMessage = "User Must Have A Name")]
        public string UserName { get; set; }
        [Required (ErrorMessage = "User Must Have A Passowrd")]
        public string Password { get; set; }
        
    }
}
