using System;
using System.Collections.Generic;

namespace FriendsBook.Core.Domain
{
    public class Comment
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get;protected set; }
        public string SenderName { get; protected set; }
        public string Message { get;protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected Comment(User user,string message)
        {
            Id = Guid.NewGuid();
            UserId = user.Id;
            SenderName = user.Name;
            AddMessage(message);
            CreatedAt = DateTime.UtcNow;
        }

        public void AddMessage(string message)
        {
            if(string.IsNullOrWhiteSpace(message))
            {
                throw new Exception("Message cannot be empty");
            }
            else if(message.Length>300)
            {
                throw new Exception("Your message is too long");
            }

            Message = message;           
        }

        public static Comment Create(User user, string message)
            => new Comment(user, message);
    }
}