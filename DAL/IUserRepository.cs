using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;

namespace DAL
{
    public interface IUserRepository
    {
        void AdminRegistration(User newAdmin);
        void UserRegistration(User newUser);
        List<User> GetAllUsers();
        User GetUserByID(int UserID);
        void UpdateUser(User newUser);
        User Login(User user);
        void ChangePassword(User user, string NewPassword);

    }
}
