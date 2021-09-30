using System;

namespace Backend.Models
{
    public class Comment
    {
        public int ID {get; set;}
        public virtual User User {get; set;}
        public int UserID {get; set;}
        public virtual Movie Movie {get; set;}
        public int MovieID {get; set;}
        public string Text {get; set;}
        public DateTime Date {get; set;}
    }
}