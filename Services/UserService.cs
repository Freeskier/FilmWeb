using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Authentication;
using Backend.Database;
using Backend.DTOs;
using Backend.Models;
using Backend.Repositories;
using Backend.Services;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMovieRepository _movieRepository;

        public UserService(IUserRepository userRepository, IMovieRepository movieRepository)
        {
            _userRepository = userRepository;
            _movieRepository = movieRepository;
        }

    }
}