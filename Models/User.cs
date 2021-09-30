using System.Collections.Generic;

namespace Backend.Models
{
    public class User
    {
        public int ID {get; set;}
        public string Login {get; set;}
        public string Password {get; set;}
        public string Email {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public virtual ICollection<Movie> SeenMovies {get; set;}
        public virtual ICollection<Comment> Comments {get; set;}
        public virtual ICollection<Rating> Ratings {get; set;}

    }
}