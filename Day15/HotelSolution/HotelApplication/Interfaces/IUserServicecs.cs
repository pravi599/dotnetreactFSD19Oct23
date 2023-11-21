using HotelApplication.Models.DTOs;

namespace HotelApplication.Interfaces
{
    public interface IUserService
    {
        UserDTO Login(UserDTO userDTO);
        UserDTO Register(UserRegisterDTO userRegisterDTO);
    }
}
