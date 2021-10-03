using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Database;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private readonly DataContext _context;
        public CommentRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comment>> GetCommentsForMovie(int movieID)
        {
            return await _context.Comments.Where(x => x.MovieID == movieID).Include(x => x.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetCommentsForUser(int userID)
        {
            return await _context.Comments.Where(x => x.UserID == userID).Include(x => x.User)
                .ToListAsync();
        }
    }
}