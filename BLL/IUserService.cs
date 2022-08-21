using BLL.ModelsDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IUserService
    {
        void AddNewAdmin(CreateUserDto newAdmin);
        void AddNewUser(CreateUserDto newUser);
        List<UserDto> GetAllUsers();
        UserDto GetUserByID(int UserID);
        void UpdateUser(int UserID, UpdateUserDto newUser);

        AuthResponseDto Login(UserCredentials userCred);
        void ChangePassword(int UserID, string NewPassword);

    }
}
