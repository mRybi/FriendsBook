using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsBook.Infrastructure.DTO
{
    public class PostDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string SenderName { get; set; }
        public string Message { get; set; }
        public IEnumerable<CommentDTO> Comments { get; set; }
        public IEnumerable<UserDTO> UsersInvolved { get; set; }
    }
}
