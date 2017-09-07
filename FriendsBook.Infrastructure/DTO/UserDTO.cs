using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsBook.Infrastructure.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Email { get; protected set; }
        public string Name { get; protected set; }
        public string LastName { get; protected set; }
        public BoardDTO Board { get; protected set; }
        public IEnumerable<UserDTO> Friends { get; set; }
    }
}
