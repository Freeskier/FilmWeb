using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserWithMovies(int userID);
    }
}