using ShoppingApplication.Models.DTOs;

namespace ShoppingApplication.Interfaces
{
    public interface IUserService
    {
        UserDTO Login(UserDTO userDTO);
        UserDTO Register(UserDTO userDTO);
    }
}
