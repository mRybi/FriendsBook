using System;
using System.Collections.Generic;
using System.Linq;

namespace FriendsBook.Core.Domain
{
    public class Post
    {
        private ISet<Comment> _comments = new HashSet<Comment>();
        private ISet<User> _usersIvolved = new HashSet<User>();

        public Guid Id { get;protected set; }
        public Guid UserId { get; protected set; }
        public string SenderName { get; protected set; }
        public string Message { get;protected set; }
        public IEnumerable<Comment> Comments
        {
            get { return _comments; }
            set { _comments = new HashSet<Comment>(value); }
        }
        public IEnumerable<User> UsersInvolved
        {
            get { return _usersIvolved; }
            set { _usersIvolved = new HashSet<User>(value); }
        }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected Post(User user, string message)
        {
            Id = Guid.NewGuid();
            UserId = user.Id;
            SenderName = user.Name;
            AddMessage(message);
            CreatedAt = DateTime.UtcNow;
        }
        public static Post Create(User user, string message)
            => new Post(user, message);
        private void AddMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new Exception("Message cannot be empty");
            }
            else if (message.Length > 300)
            {
                throw new Exception("Your message is too long");
            }

            Message = message;
        }

        public void AddComment(User user,string message)
        {
            _comments.Add(Comment.Create(user, message));
            UpdatedAt = DateTime.UtcNow;
        }

        public void DeleteComment(User user)
        {
            var comm = Comments.SingleOrDefault(x => x.UserId == user.Id);//delete all comments of this user
            if(comm==null)
            {
                throw new Exception($"User {user.Name} has not commented this post. There is nothing to delete!");
            }

            _comments.Remove(comm);
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddUserToPost(User user)
        {
            var isInAlready = UsersInvolved.SingleOrDefault(x => x.Id == user.Id);
            if(isInAlready!=null)
            {
                throw new Exception($"User {user.Name} is already involved");
            }

            _usersIvolved.Add(user);
            UpdatedAt = DateTime.UtcNow;
        }

        public void DeleteUserFromPost(User user)
        {
            var isInAlready = UsersInvolved.SingleOrDefault(x => x.Id == user.Id);
            if (isInAlready == null)
            {
                throw new Exception($"User {user.Name} is not involved");
            }

            _usersIvolved.Remove(user);
            UpdatedAt = DateTime.UtcNow;
        }
    }
}