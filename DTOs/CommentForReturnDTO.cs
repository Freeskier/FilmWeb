using System;

namespace Backend.DTOs
{
    public class CommentForReturnDTO
    {
        public int ID {get; set;}
        public int UserID {get; set;}
        public int MovieID {get; set;}
        public string Text {get; set;}
        public string UserName {get; set;}
        public string Date {get; set;}
    }
}