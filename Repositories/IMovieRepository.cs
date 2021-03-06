using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetSeen(int userID);
        Task<Movie> GetMovie(int movieID);
        Task<IEnumerable<Movie>> GetAllMovies();
    }
}