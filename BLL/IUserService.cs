using BLL.ModelsDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IUserService
    {
        void AdminRegistration(CreateUserDto newAdmin);
        void UserRegistration(CreateUserDto newUser);
        List<UserDto> GetAllUsers();
        UserDto GetUserByID(int UserID);
        void UpdateUser(int UserID, UpdateUserDto newUser);
    }
}
