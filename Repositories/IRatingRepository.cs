using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Repositories
{
    public interface IRatingRepository : IRepository<Rating>
    {
        Task<IEnumerable<Rating>> GetMovieRatings(int movieID);
        Task<bool> ContainsRating(Rating rating);
    }
}