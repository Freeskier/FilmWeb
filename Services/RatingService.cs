using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Backend.DTOs;
using Backend.Models;
using Backend.Repositories;

namespace Backend.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public RatingService(IRatingRepository ratingRepository, IMovieRepository movieRepository, IMapper mapper)
        {
            _mapper = mapper;
            _ratingRepository = ratingRepository;
            _movieRepository = movieRepository;
        }
        public async Task AddRating(RatingForAddDTO rating, int userID)
        {
            var mappedRating = _mapper.Map<Rating>(rating);
            mappedRating.UserID = userID;
            if(await _ratingRepository.ContainsRating(mappedRating))
                throw new Exception("Rating for this movie is already added!");
            await _ratingRepository.AddAsync(mappedRating);
            await _ratingRepository.SaveAsync();
        }

        public async Task<IEnumerable<RatingForReturnDTO>> GetMovieRatings(int movieID)
        {
            var ratings = await _ratingRepository.GetMovieRatings(movieID);
            var mapped = _mapper.Map<IEnumerable<RatingForReturnDTO>>(ratings);
            return mapped;
        }

        public async Task RemoveRating(int movieID, int userID)
        {
            var movie = await _movieRepository.GetMovie(movieID);
            var rating = movie.Ratings.FirstOrDefault(x => x.UserID == userID);
            await _ratingRepository.RemoveAsync(rating);
            await _ratingRepository.SaveAsync();
        }
    }
}