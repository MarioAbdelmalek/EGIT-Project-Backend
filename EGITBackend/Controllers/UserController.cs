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
        public string ChangePassword(UserDto user, string NewPassword)
        {
            UserService.ChangePassword(user, NewPassword);
            return "Password Changed Successfully";

        }
    }
}
