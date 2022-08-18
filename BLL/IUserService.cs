using BLL.ModelsDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IUserService
    {
        public AuthResponseDto Login(UserDto user);
        public void ChangePassword(UserDto user, string NewPassword);


    }


}
