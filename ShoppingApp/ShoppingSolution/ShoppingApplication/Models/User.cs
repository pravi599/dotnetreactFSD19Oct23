using ShoppingApplication.Models.DTOs;
using ShoppingApplication.Models;
using System.ComponentModel.DataAnnotations;
namespace ShoppingApplication.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }

        public byte[] Password { get; set; }
        public string Role { get; set; }
        public byte[] Key { get; set; }
    }
}
