using AutoMapper;
using BLL.ModelsDto;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        IUserRepository UserRepository;

        public UserService(IMapper mapper, IUserRepository UserRepository)
        {
            this.mapper = mapper;
            this.UserRepository = UserRepository;
        }

        public void AdminRegistration(CreateUserDto newAdmin)
        {
            UserDto admin = new UserDto
            {
                UserName = newAdmin.UserName,
                FirstName = newAdmin.FirstName,
                LastName = newAdmin.LastName,
                Email = newAdmin.Email,
                HomeAddress = newAdmin.HomeAddress,
                PhoneNumber = newAdmin.PhoneNumber,
                PassportNumber = newAdmin.PassportNumber,
                Password = newAdmin.Password,
                IsAdmin = true,
                IsPowerUser = false
            };
            UserRepository.AdminRegistration(mapper.Map<User>(admin));
        }

        public List<UserDto> GetAllUsers()
        {
            var returnedUsersList = UserRepository.GetAllUsers();
            return mapper.Map<List<UserDto>>(returnedUsersList);
        }

        public UserDto GetUserByID(int UserID)
        {
            User returnedUser = UserRepository.GetUserByID(UserID);
            return mapper.Map<UserDto>(returnedUser);
        }

        public void UpdateUser(int UserID, UpdateUserDto newUser)
        {
            UserDto oldUser = GetUserByID(UserID);
            if (oldUser != null)
            {
                oldUser.UserName = newUser.UserName;
                oldUser.FirstName = newUser.FirstName;
                oldUser.LastName = newUser.LastName;
                oldUser.Email = newUser.Email;
                oldUser.HomeAddress = newUser.HomeAddress;
                oldUser.PhoneNumber = newUser.PhoneNumber;
                oldUser.PassportNumber = newUser.PassportNumber;
                oldUser.IsAdmin = newUser.IsAdmin;
                oldUser.IsPowerUser = newUser.IsPowerUser;
                UserRepository.UpdateUser(mapper.Map<User>(oldUser));
            }
        }

        public void UserRegistration(CreateUserDto newUser)
        {
            UserDto user = new UserDto
            {
                UserName = newUser.UserName,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,
                HomeAddress = newUser.HomeAddress,
                PhoneNumber = newUser.PhoneNumber,
                PassportNumber = newUser.PassportNumber,
                Password = newUser.Password,
                IsAdmin = false,
                IsPowerUser = false
            };
            UserRepository.UserRegistration(mapper.Map<User>(user));
        }
    }
}
