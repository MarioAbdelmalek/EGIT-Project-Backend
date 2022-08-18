using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;

namespace DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly PostgreSqlContext context;

        public UserRepository(PostgreSqlContext context)
        {
            this.context = context;
        }
        public User Login(User user)
        {
            Func<User, bool> expression = p => p.UserName == user.UserName && p.Password == user.Password;
            return context.Users.Find(expression);
        }

        public void ChangePassword(User user, string NewPassword)
        {
            user.Password = NewPassword;
            context.Users.Update(user);
            context.SaveChanges();

        }
    }
}
