using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Backend.DTOs;
using Backend.Models;
using Backend.Repositories;

namespace Backend.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public MovieService(IMovieRepository movieRepository, IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
            _userRepository = userRepository;
        }

        public async Task AddMovie(MovieForAddDTO movie)
        {
            var mapped = _mapper.Map<Movie>(movie);
            await _movieRepository.AddAsync(mapped);
        }


        public async Task<IEnumerable<MovieForReturnDTO>> GetAllMovies()
        {
            var movies = await _movieRepository.GetAllAsync();
            var mapped = _mapper.Map<IEnumerable<MovieForReturnDTO>>(movies);
            return mapped;
        }

        public async Task<MovieForReturnDTO> GetMovie(int id)
        {
            var movie = await _movieRepository.GetAsync(id);
            var mapped = _mapper.Map<MovieForReturnDTO>(movie);
            return mapped;
        }

        public async Task<IEnumerable<MovieForReturnDTO>> GetSeen(int userID)
        {
            var movie = await _movieRepository.GetSeen(userID);
            var mapped = _mapper.Map<IEnumerable<MovieForReturnDTO>>(movie);
            return mapped;

        }

        public async Task AddToSeen(int movieID, int userID)
        {
            var user = await _userRepository.GetUserWithMovies(userID);
            var movie = await _movieRepository.GetAsync(movieID);
            if(user.SeenMovies.Contains(movie))
                throw new Exception("Movie is already in list.");
            user.SeenMovies.Add(movie);
            await _userRepository.SaveAsync();
        }
    }
}