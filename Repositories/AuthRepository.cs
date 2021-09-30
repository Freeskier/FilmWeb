using System;
using System.Threading.Tasks;
using Backend.Database;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<User> LoginAsync(string login, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Login == login && x.Password == password);
            return user;
        }

        public async Task<User> RegisterAsync(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> UserExist(string login)
        {
            if (await _context.Users.AnyAsync(x => x.Login == login)) return true;
            else return false;
        }
    }
}