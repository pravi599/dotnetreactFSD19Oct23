using ShoppingApplication.Models.DTOs;

namespace ShoppingApplication.Interfaces
{
    public interface ITokenService
    {
        string GetToken(UserDTO user);
    }
}
