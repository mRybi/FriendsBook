using FriendsBook.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FriendsBook.Infrastructure.Services
{
    public interface IUserService:IService
    {
        Task<UserDTO> GetAsync(string email);
        Task<IEnumerable<UserDTO>> BrowseAsync();
        Task RegisterAsync(string email, string name, string password);
        Task LoginAsync(string email, string password);
    }
}
