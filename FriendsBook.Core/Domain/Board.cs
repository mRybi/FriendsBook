using System.Collections.Generic;
using System.Linq;
using System;

namespace FriendsBook.Core.Domain
{
    public class Board
    {
        private ISet<Post> _posts = new HashSet<Post>();

        public Guid UserId { get; protected set; }
        public string UserName { get; protected set; }
        public IEnumerable<Post> PostedThings
        {
            get { return _posts; }
            set { _posts = new HashSet<Post>(value); }
        }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }


        public Board(User user)
        {
            UserId = user.Id;
            UserName = user.Name;
        }

        public void AddPost(Post post)
        {
            _posts.Add(post);
            CreatedAt = DateTime.UtcNow;
        }

        public void DeletePost(Post post)
        {
            var isPosted = PostedThings.SingleOrDefault(x => x.Id == post.Id);
            if(isPosted==null)
            {
                throw new Exception($"No post matching Id to remove");
            }
            _posts.Remove(post);
            UpdatedAt = DateTime.UtcNow;
        }
    }
}