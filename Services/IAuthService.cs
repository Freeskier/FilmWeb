using System.Threading.Tasks;
using Backend.DTOs;
using Backend.Models;

namespace Backend.Services
{
    public interface IAuthService
    {
        Task<User> RegisterAsync(UserForRegisterDTO user);
        Task<UserForReturnDTO> LoginAsync(UserForLoginDTO user);
    }
}