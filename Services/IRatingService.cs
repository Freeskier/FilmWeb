using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.DTOs;
using Backend.Models;

namespace Backend.Services
{
    public interface IRatingService
    {
        Task AddRating(RatingForAddDTO rating, int userID);
        Task RemoveRating(int ratingID);
        Task<IEnumerable<RatingForReturnDTO>> GetMovieRatings(int movieID);
        
    }
}