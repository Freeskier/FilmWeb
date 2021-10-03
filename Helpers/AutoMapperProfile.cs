using System;
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
           CreateMap<Comment, CommentForReturnDTO>()
                .ForMember(dest => dest.UserName, opt =>
                    opt.MapFrom(src => src.User.Login))
                    .ForMember(dest => dest.Date, opt =>
                    opt.MapFrom(src => src.Date.Day + "-" + src.Date.Month + "-" + src.Date.Year));
           CreateMap<Rating, RatingForReturnDTO>();
           CreateMap<CommentForAddDTO, Comment>();
           CreateMap<RatingForAddDTO, Rating>();
           CreateMap<MovieForAddDTO, Movie>();
           CreateMap<Movie, MovieForReturnDTO>()
                .ForMember(dest => dest.Rating, opt => 
                    opt.MapFrom(src => Math.Round(src.Ratings.AveregeRating(), 2)))
                .ForMember(dest => dest.ProductionDate, opt =>
                    opt.MapFrom(src => src.ProductionDate.Day + "-" + src.ProductionDate.Month + "-" + src.ProductionDate.Year));
        }
        
    }
}