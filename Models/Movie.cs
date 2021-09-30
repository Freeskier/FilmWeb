using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public class Movie
    {
        public virtual ICollection<Rating> Ratings {get; set;}
        public virtual ICollection<Comment> Comments {get; set;}
        public virtual ICollection<User> SeenBy {get; set;}
        public int ID {get; set;}
        public string Title {get; set;}
        public string Director {get; set;}
        public string Screenwriter {get; set;}
        public DateTime ProductionDate {get; set;}
        public string FilmGenre {get; set;}
        public string DescriptionShort {get; set;}
        public string DescriptionLong {get; set;}
        public string ImageURL {get; set;}
        public int DurationTimeMinutes {get; set;}
    }

}