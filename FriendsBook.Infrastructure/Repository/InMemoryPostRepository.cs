using FriendsBook.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using FriendsBook.Core.Domain;
using System.Threading.Tasks;
using System.Linq;

namespace FriendsBook.Infrastructure.Repository
{
    public class InMemoryPostRepository : IPostRepository
    {
        private static readonly ISet<Post> _posts = new HashSet<Post>();


        public async Task<Post> GetAsync(Guid id)
            => await Task.FromResult(_posts.SingleOrDefault(x => x.Id == id));

        public async Task<IEnumerable<Post>> GetAll()
            => await Task.FromResult(_posts);

        public async Task<IEnumerable<Comment>> GetAllCommentsAsync(Post post)
            => await Task.FromResult(post.Comments);

        public async Task<IEnumerable<Post>> GetAllUserPostsAsync(User user)
            => await Task.FromResult(user.Board.PostedThings);

        public async Task<IEnumerable<User>> GetAllUsersInvolvedAsync(Post post)
            => await Task.FromResult(post.UsersInvolved);

        public async Task AddAsync(Post post)
            => await Task.FromResult(_posts.Add(post));

        public async Task DeleteAsync(Guid id)
            => await Task.FromResult(_posts.SingleOrDefault(x => x.Id == id));

        public async Task UpdateAsync(Post post)
        {
            await Task.CompletedTask;
        }
    }
}
