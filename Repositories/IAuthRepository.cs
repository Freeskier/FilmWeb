using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Repositories
{
    public interface IAuthRepository
    {
        Task<User> RegisterAsync(User user);
        Task<User> LoginAsync(string login, string password);
        Task<bool> UserExist(string login);
    }
}