using BLL.ModelsDto;
using DAL.Models;
using DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace BLL
{
    public class UserService : IUserService
    {
        private readonly IUserRepository UserRepository;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;



        public UserService(IUserRepository UserRepository, IConfiguration configuration,IMapper mapper)
        {
            this.UserRepository = UserRepository;
            this.configuration = configuration;
            this.mapper = mapper;
        }

        public AuthResponseDto Login(UserDto user)
        {

            var response = UserRepository.Login(mapper.Map<User>(user));
            if (response == null)
            {
                return new AuthResponseDto { Response = "Login failed" , IsValid=false};
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(configuration["JWT:MyPassword"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, response.UserName)
                }),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new AuthResponseDto { Response = "Login Successful", Token = tokenHandler.WriteToken(token),IsValid=true };
        }

        public void ChangePassword(UserDto user, string NewPassword)
        {
            UserRepository.ChangePassword(mapper.Map<User>(user), NewPassword);

        }
    }
}

