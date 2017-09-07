using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsBook.Infrastructure.DTO
{
    public class BoardDTO
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public IEnumerable<PostDTO> PostedThings { get; set; }
    }
}
