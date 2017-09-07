using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsBook.Infrastructure.DTO
{
    public class CommentDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string SenderName { get; set; }
        public string Message { get; set; }
    }
}
