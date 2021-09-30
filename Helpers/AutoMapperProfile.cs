using AutoMapper;
using Backend.DTOs;
using Backend.Models;

namespace Backend.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
           CreateMap<UserForRegisterDTO, User>();
           CreateMap<User, UserForReturnDTO>();
           CreateMap<Comment, CommentForReturnDTO>();
           CreateMap<Rating, RatingForReturnDTO>();
           CreateMap<Movie, MovieForReturnDTO>();
           CreateMap<MovieForAddDTO, Movie>();
           CreateMap<CommentForAddDTO, Comment>();
           CreateMap<RatingForAddDTO, Rating>();
        }
        
    }
}