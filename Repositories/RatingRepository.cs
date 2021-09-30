using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Database;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class RatingRepository : Repository<Rating>, IRatingRepository
    {
        private readonly DataContext _context;
        public RatingRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rating>> GetMovieRatings(int movieID)
        {
            return await _context.Ratings.Where(x => x.MovieID == movieID).ToListAsync();
        }

        public async Task<bool> ContainsRating(Rating rating)
        {
            return await _context.Ratings.FirstOrDefaultAsync(x => x.MovieID == rating.MovieID && x.UserID == rating.UserID) != null;
        }
    }
}