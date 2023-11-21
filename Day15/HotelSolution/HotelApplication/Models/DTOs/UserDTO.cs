﻿using System.ComponentModel.DataAnnotations;

namespace HotelApplication.Models.DTOs
{
    public class UserDTO
    {

        [Required(ErrorMessage = "User Email cannot be empty")]
        public string UserEmail { get; set; }

        public string? Role { get; set; }

        public string? Token { get; set; }

        [Required(ErrorMessage = "Password cannot be empty")]
        public string Password { get; set; }
    }
}