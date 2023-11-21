
using System.Security.Cryptography;
using System.Text;
using HotelApplication.Interfaces;
using HotelApplication.Models.DTOs;
using HotelApplication.Models;

namespace HotelApplication.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<string, User> _repository;
        private readonly ITokenService _tokenService;

        public UserService(IRepository<string, User> repository, ITokenService tokenService)
        {
            _repository = repository;
            _tokenService = tokenService;
        }
        /// <summary>
        /// Logins an user by validating their credentials
        /// </summary>
        /// <param name="userDTO">Login credentails</param>
        /// <returns>Returns token on successfull login of User</returns>
        public UserDTO Login(UserDTO userDTO)
        {
            var user = _repository.GetById(userDTO.UserEmail);
            if (user != null)
            {
                HMACSHA512 hmac = new HMACSHA512(user.Key);
                var userpass = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                for (int i = 0; i < userpass.Length; i++)
                {
                    if (user.Password[i] != userpass[i])
                        return null;
                }
                userDTO.Role = user.Role;
                userDTO.Token = _tokenService.GetToken(userDTO);
                userDTO.Password = "";
                return userDTO;
            }
            return null;
        }
        /// <summary>
        /// Registers new user into the application
        /// </summary>
        /// <param name="userRegisterDTO">Contains user data for registeration </param>
        /// <returns>Returns token on successfull registeration</returns>
        public UserDTO Register(UserRegisterDTO userRegisterDTO)
        {
            HMACSHA512 hmac = new HMACSHA512();
            User user = new User()
            {
                UserEmail = userRegisterDTO.UserEmail,
                Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(userRegisterDTO.Password)),
                PhoneNo = userRegisterDTO.PhoneNo,
                Address = userRegisterDTO.Address,
                Key = hmac.Key,
                Role = userRegisterDTO.Role
            };
            var result = _repository.Add(user);
            if (result != null)
            {
                userRegisterDTO.Token = _tokenService.GetToken(userRegisterDTO);
                userRegisterDTO.Password = "";
                userRegisterDTO.ReTypePassword = "";
                return userRegisterDTO;
            }
            return null;

        }
    }
}