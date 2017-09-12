using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsBook.Infrastructure.Command
{
    public class CreateUser
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }
    }
}
