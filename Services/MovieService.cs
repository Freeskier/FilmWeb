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
        private readonly IRatingRepository _ratingRepository;
        public MovieService(IMovieRepository movieRepository, IUserRepository userRepository, IRatingRepository ratingRepository, IMapper mapper)
        {
            _ratingRepository = ratingRepository;
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

            foreach(var m in movies)
            {
                var map = mapped.FirstOrDefault(x => x.ID == m.ID);
                CalculateRating(m, ref map);
            }
            return mapped;
        }

        public async Task<MovieForReturnDTO> GetMovie(int id)
        {
            var movie = await _movieRepository.GetMovie(id);
            var mapped = _mapper.Map<MovieForReturnDTO>(movie);
            CalculateRating(movie, ref mapped);
            return mapped;
        }

        public async Task<IEnumerable<MovieForReturnDTO>> GetSeen(int userID)
        {
            var movie = await _movieRepository.GetSeen(userID);
            var mapped = _mapper.Map<IEnumerable<MovieForReturnDTO>>(movie);
            foreach(var m in movie)
            {
                var map = mapped.FirstOrDefault(x => x.ID == m.ID);
                CalculateRating(m, ref map);
            }
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

        private void CalculateRating(Movie movie, ref MovieForReturnDTO forReturnDTO)
        {
            if(movie.Ratings!= null)
            {
                float rating = (float) movie.Ratings.Sum(x => x.Stars) / (float)movie.Ratings.Count;
                forReturnDTO.Rating = rating;
            }
        }
    }
}