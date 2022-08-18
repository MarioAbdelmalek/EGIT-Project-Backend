using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IUserRepository
    {
        void AdminRegistration(User newAdmin);
        void UserRegistration(User newUser);
        List<User> GetAllUsers();
        User GetUserByID(int UserID);
        void UpdateUser(User newUser);
    }
}
