using System;
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
        private readonly IMapper _mapper;
        public RatingService(IRatingRepository ratingRepository, IMapper mapper)
        {
            _mapper = mapper;
            _ratingRepository = ratingRepository;

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

        public async Task RemoveRating(int ratingID)
        {
            var rating = await _ratingRepository.GetAsync(ratingID);
            await _ratingRepository.RemoveAsync(rating);
            await _ratingRepository.SaveAsync();
        }
    }
}