using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;

namespace DAL
{
    public interface IUserRepository
    {
        void AddNewAdmin(User newAdmin);
        void AddNewUser(User newUser);
        List<User> GetAllUsers();
        User GetUserByID(int UserID);
        void UpdateUser(User newUser);
        User Login(User user);
        void ChangePassword(int UserID, string NewPassword);

    }
}
