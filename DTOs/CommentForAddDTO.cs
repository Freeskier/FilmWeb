using System;

namespace Backend.DTOs
{
    public class CommentForAddDTO
    {
        public int MovieID {get; set;}
        public string Text {get; set;}
        public DateTime Date {get; set;}
    }
}