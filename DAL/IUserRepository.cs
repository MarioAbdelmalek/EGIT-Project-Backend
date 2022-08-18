using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;

namespace DAL
{
    public interface IUserRepository
    {
        public User Login(User user);
        public void ChangePassword(User user, string NewPassword);

    }
}
