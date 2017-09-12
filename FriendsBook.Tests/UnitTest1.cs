using FriendsBook.Infrastructure.Services;
using System;
using Xunit;

namespace FriendsBook.Tests
{
    public class UnitTest1
    {
        private IUserService _userService;

        public UnitTest1(IUserService userService)
        {
            _userService = userService;    
        }
        [Fact]
        public void Test1()
        {
            var user = _userService.GetAsync("email@wp.pl");
            if(user!=null)
            {
                throw new Exception("there is already user with that email adress");
            }
            _userService.RegisterAsync("email@wp.pl", "user", "secret");

            
        }
    }
}
