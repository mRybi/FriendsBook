using FriendsBook.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using FriendsBook.Core.Domain;
using System.Threading.Tasks;
using System.Linq;

namespace FriendsBook.Infrastructure.Repository
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static readonly ISet<User> _users = new HashSet<User>();

        public async Task<IEnumerable<User>> GetAllAsync()
            =>await Task.FromResult(_users);

        public async Task<User> GetAsync(Guid id)
            => await Task.FromResult(_users.SingleOrDefault(x => x.Id == id));

        public async Task<User> GetAsync(string email)
            => await Task.FromResult(_users.SingleOrDefault(x => x.Email == email));

        public async Task AddAsync(User user)
            =>await Task.FromResult(_users.Add(user));

        public async Task DeleteAsync(Guid id)
        {
            var user = await GetAsync(id);
            _users.Remove(user);
            await Task.CompletedTask;
        }               

        public async Task UpdateAsync(User user)
        {
            await Task.CompletedTask;
        }
    }
}
