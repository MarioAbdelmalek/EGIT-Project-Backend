using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EGITBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService UserService;
        public UserController(IUserService UserService)
        {
            this.UserService = UserService;
        }

        [Route("adminRegistration")]
        [HttpPost]
        public void AdminRegistration(CreateUserDto newAdmin)
        {
            UserService.AdminRegistration(newAdmin);
        }

        [Route("userRegistration")]
        [HttpPost]
        public void UserRegistration(CreateUserDto newUser)
        {
            UserService.UserRegistration(newUser);
        }

        [Route("getUserById")]
        [HttpGet]
        public UserDto GetUserByID(int UserID)
        {
            return UserService.GetUserByID(UserID);
        }

        [Route("updateUser")]
        [HttpPut]
        public void UpdateUser(int UserID, UpdateUserDto newUser)
        {
            UserService.UpdateUser(UserID, newUser);
        }

        [Route("getAllUsers")]
        [HttpGet]
        public IEnumerable<UserDto> GetAllUsers()
        {
            return UserService.GetAllUsers();
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login(UserDto user)
        {
            var token = UserService.Login(user);

            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }

        [Authorize]
        [Route("changePassword")]
        [HttpPost]
        public string ChangePassword(int UserID, string NewPassword)
        {
            UserService.ChangePassword(UserID, NewPassword);
            return "Password Changed Successfully";
        }
    }
}
