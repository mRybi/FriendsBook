using FriendsBook.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Collections;
using FriendsBook.Infrastructure.DTO;
using FriendsBook.Infrastructure.Command;

namespace FriendsBook.Api.Controllers
{
    public class UsersController:Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var users =await _userService.BrowseAsync();

            return Json(users);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUser command)
        {
            await _userService.RegisterAsync(command.Email, command.Name, command.Password);

            return Created($"users/{command.Email}", null);
        }
    }
}
