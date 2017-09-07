using FriendsBook.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FriendsBook.Core.Repository
{
    public interface IPostRepository:IRepository
    {
        Task<Post> GetAsync(Guid id);
        Task<IEnumerable<Post>> GetAllUserPostsAsync(User user);
        Task<IEnumerable<Post>> GetAll();
        Task AddAsync(Post post);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Post post);
        Task<IEnumerable<Comment>> GetAllCommentsAsync(Post post);
        Task<IEnumerable<User>> GetAllUsersInvolvedAsync(Post post);
    }
}
