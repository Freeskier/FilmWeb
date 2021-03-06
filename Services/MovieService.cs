using System;
using System.Collections.Generic;
using System.Linq;
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
            var movies = await _movieRepository.GetAllMovies();
            var mapped = _mapper.Map<IEnumerable<MovieForReturnDTO>>(movies);
            return mapped;
        }

        public async Task<MovieForReturnDTO> GetMovie(int movieID, int userID)
        {
            var movie = await _movieRepository.GetMovie(movieID);
            var mapped = _mapper.Map<Movie, MovieForReturnDTO>(movie, opt => 
                opt.AfterMap((src, dest) => { 
                    dest.IsSeen = src.SeenBy.Any(x => x.ID == userID);
                    var rating = src.Ratings.FirstOrDefault(x => x.UserID == userID);
                    dest.UserRating = (rating != null)? rating.Stars : -1;
            }));
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

        public async Task<bool> IsSeen(int movieID, int userID)
        {
            var movie = await _movieRepository.GetMovie(movieID);
            return movie.SeenBy.Any(x => x.ID == userID);
        }

        public async Task DeleteSeen(int movieID, int userID)
        {
            var user = await _userRepository.GetUserWithMovies(userID);
            var movie = await _movieRepository.GetAsync(movieID);
            user.SeenMovies.Remove(movie);
            await _userRepository.SaveAsync();
        }
    }
}