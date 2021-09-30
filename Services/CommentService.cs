using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Backend.DTOs;
using Backend.Models;
using Backend.Repositories;

namespace Backend.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IUserRepository userRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task AddComment(CommentForAddDTO comment, int userID)
        {
            var mapped = _mapper.Map<Comment>(comment);
            mapped.UserID = userID;
            await _commentRepository.AddAsync(mapped);
            await _commentRepository.SaveAsync();
        }

        public async Task<Comment> EditComment(CommentForEditDTO comment)
        {
            var mappedComment = _mapper.Map<Comment>(comment);
            await _commentRepository.UpdateAsync(mappedComment);
            await _commentRepository.SaveAsync();
            return mappedComment;
        }

        public async Task<IEnumerable<CommentForReturnDTO>> GetMovieComments(int movieID)
        {
            var comments = await _commentRepository.GetCommentsForMovie(movieID);
            var mapped = _mapper.Map<IEnumerable<CommentForReturnDTO>>(comments);
            return mapped;
        }

        public async Task<IEnumerable<CommentForReturnDTO>> GetUserComments(int userID)
        {
            var comments = await _commentRepository.GetCommentsForUser(userID);
            var mapped = _mapper.Map<IEnumerable<CommentForReturnDTO>>(comments);
            return mapped;
        }

        public async Task RemoveComment(int id)
        {
            var entity = await _commentRepository.GetAsync(id);
            await _commentRepository.RemoveAsync(entity);
            await _commentRepository.SaveAsync();
        }
    }
}