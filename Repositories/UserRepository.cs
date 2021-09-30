using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Database;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetUserWithMovies(int userID)
        {
            return await _context.Users.Include(x => x.SeenMovies).FirstOrDefaultAsync(x => x.ID == userID);
        }
    }
}