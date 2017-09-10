using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FriendsBook.Infrastructure.DTO;
using FriendsBook.Core.Repository;
using AutoMapper;
using FriendsBook.Core.Domain;

namespace FriendsBook.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRespository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,IMapper mapper)
        {
            _userRespository = userRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<UserDTO>> BrowseAsync()
        {
            var users = await _userRespository.GetAllAsync();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);
        }

        public async Task<UserDTO> GetAsync(string email)
        {
            var user =await _userRespository.GetAsync(email);

            return _mapper.Map<User, UserDTO>(user);
        }

        public async Task LoginAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task RegisterAsync(Guid userId, string email, string name, string password)
        {
            var user = await _userRespository.GetAsync(email);

            if(user!=null)
            {
                throw new Exception($"User with email {user.Email} already exists");
            }
            var salt = Guid.NewGuid().ToString();//salt wymyslony nie ma encryptera jeszcze
            user = new User(userId, email, password, salt, name);
            await _userRespository.AddAsync(user);
        }
    }
}
