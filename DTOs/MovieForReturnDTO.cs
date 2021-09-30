using System;

namespace Backend.DTOs
{
    public class MovieForReturnDTO
    {
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