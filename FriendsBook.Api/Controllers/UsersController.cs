using FriendsBook.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace FriendsBook.Api.Controllers
{
    public class UsersController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Get()
        {
            var users =await _userService.BrowseAsync();

            return Json(users);
        }
    }
}
