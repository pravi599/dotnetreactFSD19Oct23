using System.ComponentModel.DataAnnotations;

namespace HotelApplication.Models.DTOs
{
    public class HotelDTO
    {

        [Required(ErrorMessage = "Hotel name cannot be empty")]
        public string HotelName { get; set; }
        [Required(ErrorMessage = "UserId cannot be empty")]


        public string UserEmail { get; set; }
        [Required(ErrorMessage = "City cannot be empty")]

        public string Address { get; set; }
        [Required(ErrorMessage = "Phone cannot be empty")]


        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "Description cannot be empty")]
        public string Description { get; set; }
    }
}