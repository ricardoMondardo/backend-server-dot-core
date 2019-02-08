﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Web.Server.Dtos.User;
using Web.Server.Services.Interface;

namespace Web.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/user/")]
    [Authorize]
    public class UserController : Controller 
    {

        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getUserData")]
        public IActionResult Get()
        {
            var userID = _userService.GetContextUserId(HttpContext.User);
            var userModel = _userService.Get(userID);

            var userDto = new UserDto()
            {
                Id = userModel.Id,
                Name = userModel.UserName + "**",
                Email = userModel.Email
            };

            return Ok(userDto);
        }
    }
}