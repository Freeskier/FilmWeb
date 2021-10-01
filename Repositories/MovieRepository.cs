using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Database;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        private readonly DataContext _context;

        public MovieRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            return await _context.Movies.Select(x => x).Include(x => x.Ratings)
                .ToListAsync();
        }

        public async Task<Movie> GetMovie(int movieID)
        {
            return await _context.Movies.Where(x => x.ID == movieID)
                .Include(x => x.Ratings).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Movie>> GetSeen(int userID)
        {
            return await _context.Movies.SelectMany(x => x.SeenBy)
                .Where(x => x.ID == userID).SelectMany(x => x.SeenMovies)
                .Include(x => x.Ratings).ToListAsync();
        }
    }
}