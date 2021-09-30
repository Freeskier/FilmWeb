namespace Backend.Models
{
    public class Rating
    {
        public int ID {get; set;}
        public virtual User User {get; set;}
        public int UserID {get; set;}
        public virtual Movie Movie {get; set;}
        public int MovieID {get; set;}
        public int Stars {get; set;}
    }
}