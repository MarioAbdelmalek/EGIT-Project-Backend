using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly PostgreSqlContext context;

        public UserRepository(PostgreSqlContext context)
        {
            this.context = context;

        }
        public void AdminRegistration(User newAdmin)
        {
            context.Users.Add(newAdmin);
            context.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public User GetUserByID(int UserID)
        {
            return context.Users.FirstOrDefault(u => u.UserID == UserID);
        }

        public void UpdateUser(User newUser)
        {
            context.Users.Update(newUser);
            context.SaveChanges();
        }

        public void UserRegistration(User newUser)
        {
            context.Users.Add(newUser);
            context.SaveChanges();
        }
    }
}
