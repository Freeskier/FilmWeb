using System;

namespace Backend.DTOs
{
    public class MovieForReturnDTO
    {
        public int ID {get; set;}
        public string Title {get; set;}
        public string Director {get; set;}
        public string Screenwriter {get; set;}
        public string ProductionDate {get; set;}
        public string FilmGenre {get; set;}
        public string DescriptionShort {get; set;}
        public string DescriptionLong {get; set;}
        public string ImageURL {get; set;}
        public int DurationTimeMinutes {get; set;}
        public float Rating {get; set;}
        public bool IsSeen {get; set;}
        public int UserRating {get; set;}
    }
}