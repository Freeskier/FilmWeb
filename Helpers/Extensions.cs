using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Models;

namespace Backend.Helpers
{
    public static class Extensions
    {
        public static float AveregeRating(this ICollection<Rating> ratings) 
        {
            if(ratings.Count == 0)
                return 0;
            return (float)ratings.Sum(x => x.Stars)/(float)ratings.Count;
        }

        public static bool IsSeen(this IEnumerable<Movie> movies, int userID, int xID)
        {
            var movie = movies.FirstOrDefault(x => x.ID == xID);
            return movie.SeenBy.Any(x => x.ID == userID);
        }

    }
}