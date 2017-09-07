using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FriendsBook.Core.Domain
{
    public class User
    {
        private ISet<User> _friends = new HashSet<User>();     

        public Guid Id { get;protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string Name { get; protected set; }
        public string LastName { get; protected set; }
        public string Country { get; protected set; }
        public string LiveIn { get; protected set; }
        public Gallery Gallery { get; protected set; }
        public Board Board { get; protected set; }
        public DateTime CreatedAt { get; protected set;  }
        public DateTime UpdatedAt { get; protected set;  }
        
       
        public IEnumerable<User> Friends
        {
            get { return _friends; }
            set { _friends = new HashSet<User>(value); }
        }

        public User(Guid id,string email,string password,string salt,string name)
        {
            Id = id;
            SetEmail(email);
            SetPassword(password, salt);
            SetName(name);
            CreatedAt = DateTime.UtcNow;
        }

        public void AddFriend(User user)
        {
            var isFriend = Friends.SingleOrDefault(x => x.Id == user.Id);

            if(isFriend!=null)
            {
                throw new Exception($"User {user.Name} is already on you friends list");
            }

            _friends.Add(user);
            UpdatedAt = DateTime.UtcNow;
        }

        public void DeleteFriend(User user)
        {
            var isFriend = Friends.SingleOrDefault(x => x.Id == user.Id);

            if(isFriend==null)
            {
                throw new Exception($"User {user.Name} is not on you friends list you can't delete him.");
            }

            _friends.Remove(user);
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("Email cannot be empty");
            else if (email.Length > 6)
                throw new Exception("Email cannot be shorter than 6 characters");

            Email = email;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password,string salt)
        {
            if(string.IsNullOrWhiteSpace(password)||string.IsNullOrWhiteSpace(salt))
            {
                throw new Exception("Password or salt cannot be empty");
            }
            else if(password.Length>30)
            {
                throw new Exception("Password cannot contain more than 30 characters");
            }
            Password = password;
            Salt = salt;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetName(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Name cannot be empty");
            }

            Name = name;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
