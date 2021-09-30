using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.DTOs;
using Backend.Models;

namespace Backend.Services
{
    public interface ICommentService
    {
        Task AddComment(CommentForAddDTO comment, int userID);
        Task<Comment> EditComment(CommentForEditDTO comment);
        Task RemoveComment(int id);
        Task<IEnumerable<CommentForReturnDTO>> GetUserComments(int userID);
        Task<IEnumerable<CommentForReturnDTO>> GetMovieComments(int movieID);
    }
}