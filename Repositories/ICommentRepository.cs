using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Repositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetCommentsForMovie(int movieID);
        Task<IEnumerable<Comment>> GetCommentsForUser(int userID);
    }
}