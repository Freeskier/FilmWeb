using System;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Authentication;
using Backend.DTOs;
using Backend.Models;
using Backend.Repositories;

namespace Backend.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repository;
        private readonly IMapper _mapper;
        private readonly IJwtAuthenticationManager _authenticationManager;

        public AuthService(IAuthRepository repository, IMapper mapper, IJwtAuthenticationManager authenticationManager)
        {
            _repository = repository;
            _mapper = mapper;
            _authenticationManager = authenticationManager;
        }

        public async Task<UserForReturnDTO> LoginAsync(UserForLoginDTO user)
        {
            var loggedUser = await _repository.LoginAsync(user.Login, user.Password);
            var token = _authenticationManager.Authenticate(loggedUser.Login, loggedUser.ID);
            var returnUser = _mapper.Map<UserForReturnDTO>(loggedUser);
            returnUser.Token = token; 
            return returnUser;
        }

        public async Task<User> RegisterAsync(UserForRegisterDTO user)
        {
            if(await _repository.UserExist(user.Login))
                throw new Exception("Login is taken!");
            
            var userToRegister = _mapper.Map<User>(user);
            return await _repository.RegisterAsync(userToRegister);
        }
    }
}