using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.DTOs;
using Backend.Models;

namespace Backend.Services
{
    public interface IMovieService
    {
        Task AddMovie(MovieForAddDTO movie);
        Task<IEnumerable<MovieForReturnDTO>> GetAllMovies();
        Task<MovieForReturnDTO> GetMovie(int movieID, int userID);
        Task AddToSeen(int movieID, int userID);
        Task DeleteSeen(int movieID, int userID);
        Task<IEnumerable<MovieForReturnDTO>> GetSeen(int userID);
        Task<bool> IsSeen(int movieID, int userID);
    }
}